using Microsoft.AspNetCore.Mvc;
using Moq;
using Nether.Leaderboard.Data;
using Nether.Leaderboard.Web.Controllers;
using Nether.Leaderboard.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Nether.Leaderboard.Web.Tests
{
    public class LeaderboardControllerTests
    {
        [Fact(DisplayName = "WhenPostedScoreIsNegativeThenReturnHTTP400")]
        public async Task WhenPostedScoreIsNegative_ThenTheApiReturns400Response()
        {
            // Arrange
            var leaderboardStore = new Mock<ILeaderboardStore>();
            var controller = new LeaderboardController(leaderboardStore.Object);

            // Act
            var result = await controller.Post(new ScoreRequestModel
            {
                Gamertag = "anonymous",
                Score = -1
            }); 

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact(DisplayName = "WhenPostedScoreIsNegativeThenTheApiDoesNotSaveScore")]
        public async Task WhenPostedScoreIsNegative_ThenTheApiDoesNotSaveScore()
        {
            // Arrange
            var leaderboardStore = new Mock<ILeaderboardStore>();
            var controller = new LeaderboardController(leaderboardStore.Object);

            // Act
            var result = await controller.Post(new ScoreRequestModel
            {
                Gamertag = "anonymous",
                Score = -1
            });

            // Assert
            leaderboardStore.Verify(o => o.SaveScoreAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        private async Task<IEnumerable<GameScore>> generateScores()
        {
            IEnumerable<GameScore> result = new List<GameScore>
            {
                new GameScore("gamertag01", 100)
            };

            await Task.Delay(10000);
            return result;
        }

        [Fact(DisplayName = "WhenCallingGetScoresThenTheApiReturnValidResult")]
        public async Task WhenCallingGetScores_ThenTheApiReturnValidResult()
        {
            // Arrange
            var leaderboardStore = new Mock<ILeaderboardStore>();
            leaderboardStore.Setup(o => o.GetScoresAsync()).Returns(generateScores());            
            var controller = new LeaderboardController(leaderboardStore.Object);

            ScoresListResponeModel<ScoreResponseModel> expected = new ScoresListResponeModel<ScoreResponseModel>();
            expected.Leaderboard = new List<ScoreResponseModel>();
            expected.Leaderboard.Add(new ScoreResponseModel
            {
                Gamertag = "gamertag01",
                Score = 100
            });
            
            //Act
            var result = await controller.Get();

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<ScoresListResponeModel<ScoreResponseModel>>(objectResult.Value);            
            Assert.Equal(expected.Leaderboard.Count, actual.Leaderboard.Count);            
        }
    }
}
