// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

using Nether.Data.Leaderboard;
using System.Linq;
using Nether.Integration.Analytics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nether.Web.Features.Leaderboard
{
    [Route("api/leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardStore _store;
        private readonly IAnalyticsIntegrationClient _analyticsIntegrationClient;

        public LeaderboardController(ILeaderboardStore store, IAnalyticsIntegrationClient analyticsIntegrationClient)
        {
            _store = store;
            _analyticsIntegrationClient = analyticsIntegrationClient;

        }

        //TODO: Add versioning support
        //TODO: Add authentication

        [HttpGet]
        public async Task<ActionResult> Get() //TODO: add swagger annotations for response shape
        {
            // Call data store
            var scores = await _store.GetAllHighScoresAsync();

            // Format response model
            var resultModel = new LeaderboardGetResponseModel
            {
                //LeaderboardEntries = scores.Cast<LeaderboardGetResponseModel.LeaderboardEntry>().ToList()
                LeaderboardEntries = scores.Select(_ => (LeaderboardGetResponseModel.LeaderboardEntry)_).ToList()
            };

            // Return result
            return Ok(resultModel);
        }

        [HttpGet("top({n})")]
        public async Task<ActionResult> GetTopAsync(int n, string partitionedBy, string country, string customTag) //TODO: add swagger annotations for response shape
        {
            // Call data store
            var scores = await _store.GetTopHighScoresAsync(n);

            // Format response model
            var resultModel = new LeaderboardGetResponseModel
            {
                LeaderboardEntries = scores.Cast<LeaderboardGetResponseModel.LeaderboardEntry>().ToList()
            };

            // Return result
            return Ok(resultModel);
        }

        [HttpGet("around({gamerTag},{nBetter},{nWorse})")]
        public async Task<ActionResult> GetLeaderboardAroundMeAsync(string gamerTag, int nBetter, int nWorse, string partitionedBy, string country, string customTag) //TODO: add swagger annotations for response shape
        {
            // Call data store
            var scores = await _store.GetScoresAroundMe(nBetter, nWorse, gamerTag);

            // Format response model
            var resultModel = new LeaderboardGetResponseModel
            {
                LeaderboardEntries = scores.Cast<LeaderboardGetResponseModel.LeaderboardEntry>().ToList()
            };

            // Return result
            return Ok(resultModel);
        }

        [HttpGet("friends")]
        public async Task<ActionResult> GetLeaderboardWithFriendsAsync() //TODO: add swagger annotations for response shape
        {
            throw new NotImplementedException();

            // Call data store
            var scores = await _store.GetAllHighScoresAsync();

            // Format response model
            var resultModel = new LeaderboardGetResponseModel
            {
                LeaderboardEntries = scores.Cast<LeaderboardGetResponseModel.LeaderboardEntry>().ToList()
            };

            // Return result
            return Ok(resultModel);
        }




        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]LeaderboardPostRequestModel score)
        {
            //TODO: Make validation more sophisticated, perhaps some games want/need negative scores
            // Validate input
            if (score.Score < 0)
            {
                // TODO log
                return BadRequest(); //TODO: return error info in body
            }

            //TODO: Handle exceptions and retries
            // For a quick implementation, assume that name is the gamertag - review later!
            var gamerTag = User.Identities
                .FirstOrDefault()
                ?.Name;
            if (string.IsNullOrWhiteSpace(gamerTag))
            {
                // TODO log
                return BadRequest(); //TODO: return error info in body
            }

            // Save score and call analytics in parallel
            await Task.WhenAll(
                _store.SaveScoreAsync(new GameScore
                {
                    Gamertag = gamerTag,
                    Country = score.Country,
                    CustomTag = score.CustomTag,
                    Score = score.Score
                }),
                _analyticsIntegrationClient.SendGameEventAsync(new ScoreAchieved
                {
                    GamerTag = gamerTag,
                    UtcDateTime = DateTime.UtcNow,
                    Score = score.Score
                }));

            // Return result
            return Ok();
        }
    }
}

