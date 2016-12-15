﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Nether.Web.IntegrationTests.PlayerManagement
{
    public class PlayerManagementTests : WebTestBase
    {
        private const string BaseUri = "/api/";
        private HttpClient _client;

        public PlayerManagementTests()
        {
            _client = GetClient();
        }

        [Fact]
        public async Task I_can_get_my_player_info()
        {
            PlayerGetResponse myPlayer = await GetPlayerAsync();
        }

        [Fact]
        public async Task I_can_update_my_info()
        {
            PlayerGetResponse beforeUpdate = await GetPlayerAsync();

            string newCountry = Guid.NewGuid().ToString();
            await UpdatePlayerAsync(newCountry);

            PlayerGetResponse afterUpdate = await GetPlayerAsync();
            Assert.Equal(newCountry, afterUpdate.Player.Country);
        }

        [Fact]
        public async Task As_a_user_i_cannot_add_new_players()
        {
            await AddNewPlayer(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), null,
                HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task As_an_admin_i_can_add_new_players()
        {
            _client = GetAdminClient();

            string gamerTag = Guid.NewGuid().ToString();
            var result = await AddNewPlayer(gamerTag, Guid.NewGuid().ToString(), null);

            Assert.Equal("/api/players/" + gamerTag, result.Item1.Headers.GetValues("Location").First());
            Assert.Equal($"{{\"gamerTag\":\"{gamerTag}\"}}", result.Item2);
        }

        [Fact]
        public async Task As_an_admin_i_can_get_all_players()
        {
            _client = GetAdminClient();

            PlayerListGetResponse response = await GetPlayersAsync();

            Assert.NotNull(response.Players);
            Assert.True(response.Players.Length > 0);
        }

        [Fact]
        public async Task As_a_normal_user_I_cant_get_player_list()
        {
            PlayerListGetResponse response = await GetPlayersAsync(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task As_an_admin_I_can_create_and_list_groups()
        {
            _client = GetAdminClient();

            string groupName = Guid.NewGuid().ToString();

            var g = new GroupEntry
            {
                Name = groupName,
                Description = "fake"
            };

            // validate group response
            var groupResponse = await CreateGroup(g, HttpStatusCode.Created);
            Assert.Equal("/api/groups/" + groupName, groupResponse.Item1.Headers.GetValues("Location").First());
            Assert.Equal($"{{\"groupName\":\"{groupName}\"}}", groupResponse.Item2);

            //list groups and check the created group is in the list
            GroupListResponse allGroups = await GetAllGroups();
            Assert.True(allGroups.Groups.Any(gr => gr.Name == groupName));
        }

        [Fact]
        public async Task As_a_users_I_cannot_create_groups()
        {
            await CreateGroup(new GroupEntry
            {
                Name = "fail"
            }, HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task I_can_get_a_group_by_name()
        {
            _client = GetAdminClient();

            string name = Guid.NewGuid().ToString();

            await CreateGroup(new GroupEntry
            {
                Name = name
            });

            GroupGetResponse g = await GetGroupByName(name);

            Assert.Equal(name, g.Group.Name);
        }

        [Fact]
        public async Task Admin_can_update_groups()
        {
            _client = GetAdminClient();

            string name = Guid.NewGuid().ToString();

            await CreateGroup(new GroupEntry { Name = name, Description = "before change" });

            await UpdateGroup(new GroupEntry { Name = name, Description = "after change" });

            GroupGetResponse group = await GetGroupByName(name);

            Assert.Equal("after change", group.Group.Description);
        }

        [Fact]
        public async Task Adding_and_removing_a_player_to_a_group()
        {
            _client = GetAdminClient();

            //create test group
            string groupName = Guid.NewGuid().ToString();
            await CreateGroup(new GroupEntry { Name = groupName });

            //add myself to this group
            await AddPlayerToGroup(groupName, gamertag);

            //check that i'm in the group now
            GroupMembersResponseModel groupMembers = await GetGroupMembers(groupName);
            Assert.True(groupMembers.Gamertags.Any(m => m == gamertag));

            //remove me from this group
            await DeletePlayerFromGroup(groupName, gamertag);

            //check group has no gamertag of mine anymore
            groupMembers = await GetGroupMembers(groupName);
            Assert.True(!groupMembers.Gamertags.Any(m => m == gamertag));
        }

        [Fact]
        public async Task I_can_list_group_members()
        {
            _client = GetAdminClient();

            string groupName = Guid.NewGuid().ToString();
            await CreateGroup(new GroupEntry { Name = groupName, Members = new[] { gamertag, "testUserGamerTag" } });

            GroupMembersResponseModel group = await GetGroupMembers(groupName);

            Assert.Equal(2, group.Gamertags.Length);
        }

        [Fact]
        public async Task I_can_find_out_which_groups_I_belong_to()
        {
            _client = GetAdminClient();

            //first create two groups and add me to them
            string g1 = Guid.NewGuid().ToString();
            string g2 = Guid.NewGuid().ToString();
            await CreateGroup(new GroupEntry { Name = g1, Members = new[] { gamertag } });
            await CreateGroup(new GroupEntry { Name = g2, Members = new[] { gamertag } });

            //get my groups
            GroupListResponse groups = await GetPlayerGroups();
            Assert.True(groups.Groups.Any(g => g.Name == g1));
            Assert.True(groups.Groups.Any(g => g.Name == g2));
        }

        #region [ REST helpers ]

        private async Task<GroupListResponse> GetPlayerGroups(string gamerTag = null, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            if (gamerTag == null)
            {
                return await HttpGet<GroupListResponse>(_client, BaseUri + "player/groups", expectedCode);
            }
            else
            {
                return await HttpGet<GroupListResponse>(_client, BaseUri + "players/" + gamerTag + "/groups", expectedCode);
            }
        }

        private async Task<GroupMembersResponseModel> GetGroupMembers(string groupName, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            return await HttpGet<GroupMembersResponseModel>(_client, $"{BaseUri}groups/{groupName}/players", expectedCode);
        }

        private async Task DeletePlayerFromGroup(string groupName, string playerName, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{BaseUri}groups/{groupName}/players/{playerName}");

            Assert.Equal(expectedCode, response.StatusCode);
        }

        private async Task AddPlayerToGroup(string groupName, string playerName = null, HttpStatusCode expetectedCode = HttpStatusCode.OK)
        {
            HttpResponseMessage response;

            if (playerName == null)
            {
                response = await _client.PutAsync($"{BaseUri}player/groups/{groupName}", null);
            }
            else
            {
                response = await _client.PutAsync($"{BaseUri}players/{playerName}/groups/{groupName}", null);
            }

            Assert.Equal(expetectedCode, response.StatusCode);
        }

        private async Task<Tuple<HttpResponseMessage, string>> CreateGroup(GroupEntry group, HttpStatusCode expectedCode = HttpStatusCode.Created)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(BaseUri + "groups", group);

            Assert.Equal(expectedCode, response.StatusCode);

            string s = await response.Content.ReadAsStringAsync();

            return Tuple.Create(response, s);
        }

        private async Task UpdateGroup(GroupEntry group, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(BaseUri + "groups/" + group.Name, group);

            Assert.Equal(expectedCode, response.StatusCode);
        }

        private async Task<GroupListResponse> GetAllGroups(HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            return await HttpGet<GroupListResponse>(_client, BaseUri + "groups", expectedCode);
        }

        private async Task<GroupGetResponse> GetGroupByName(string name, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            return await HttpGet<GroupGetResponse>(_client, BaseUri + "groups/" + name, expectedCode);
        }

        private async Task<PlayerListGetResponse> GetPlayersAsync(HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            return await HttpGet<PlayerListGetResponse>(_client, BaseUri + "players", expectedCode);
        }

        private async Task<PlayerGetResponse> GetPlayerAsync(HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            return await HttpGet<PlayerGetResponse>(_client, BaseUri + "player");
        }

        private async Task UpdatePlayerAsync(string country, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(BaseUri + "player",
                new PlayerPostRequest
                {
                    Country = country,
                    CustomTag = null,
                    Gamertag = this.gamertag
                });
            Assert.Equal(expectedCode, response.StatusCode);
        }

        private async Task<Tuple<HttpResponseMessage, string>> AddNewPlayer(
            string gamerTag,
            string country,
            string customTag,
            HttpStatusCode expectedCode = HttpStatusCode.Created)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(BaseUri + "players",
                new PlayerPostRequest
                {
                    Gamertag = gamerTag,
                    Country = country,
                    CustomTag = customTag
                });
            Assert.Equal(expectedCode, response.StatusCode);

            string s = await response.Content.ReadAsStringAsync();

            return Tuple.Create(response, s);
        }

        public class GroupMembersResponseModel
        {
            public string[] Gamertags { get; set; }
        }

        public class PlayerListGetResponse
        {
            public PlayerEntry[] Players { get; set; }
        }

        public class GroupListResponse
        {
            public GroupEntry[] Groups { get; set; }
        }

        public class PlayerGetResponse
        {
            public PlayerEntry Player { get; set; }
        }

        public class GroupGetResponse
        {
            public GroupEntry Group { get; set; }
        }

        public class PlayerEntry
        {
            public string Gamertag { get; set; }
            public string Country { get; set; }
            public string CustomTag { get; set; }
        }

        public class PlayerPostRequest
        {
            public string Gamertag { get; set; }
            public string Country { get; set; }
            public string CustomTag { get; set; }
        }

        public class GroupEntry
        {
            public string Name { get; set; }
            public string CustomType { get; set; }
            public string Description { get; set; }
            public string[] Members { get; set; }
        }

        #endregion
    }
}