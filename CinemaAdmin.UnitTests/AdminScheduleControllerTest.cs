using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using CinemaAdmin.Administration.Controllers;

namespace CinemaAdmin.UnitTests
{
    [TestClass]
    public class AdminScheduleControllerTest
    {

        [TestMethod]
        public void Index_Contains_All_Schedules()
        {
            // Arrange - create the mock repository
            Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
            mock.Setup(m => m.Schedules).Returns(new Schedule[] {
                new Schedule {
                    Id = 7,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = false
                    },
                new Schedule
                {
                    Id = 8,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = true
                },

                new Schedule
                {
                    Id = 9,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = false
                }
            });
            // Arrange - create a controller
            AdminScheduleController target = new AdminScheduleController(mock.Object, null, null);
            // Action
            Schedule[] result = ((IEnumerable<Schedule>)target.ScheduleIndex().ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(7, result[0].Id);
            Assert.AreEqual(8, result[1].Id);
            Assert.AreEqual(9, result[2].Id);
        }

        [TestMethod]
        public void Can_Edit_Schedule()
        {
            // Arrange - create the mock repository
            Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
            mock.Setup(m => m.Schedules).Returns(new Schedule[] {
            new Schedule {
                    Id = 1,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = false
                    },
                new Schedule
                {
                    Id = 2,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = true
                },

                new Schedule
                {
                    Id = 3,
                    hallFK = 1,
                    movieFK = 1,
                    isHoliday = false
                }
            });
            // Arrange - create the controller
            AdminScheduleController target = new AdminScheduleController(mock.Object, null, null);

            // Act
            Schedule p1 = target.ScheduleEdit(1).ViewData.Model as Schedule;
            Schedule p2 = target.ScheduleEdit(2).ViewData.Model as Schedule;
            Schedule p3 = target.ScheduleEdit(3).ViewData.Model as Schedule;
            // Assert
            Assert.AreEqual(1, p1.Id);
            Assert.AreEqual(2, p2.Id);
            Assert.AreEqual(3, p3.Id);
        }
        [TestMethod]
        public void Cannot_Edit_Nonexistent_Schedule()
        {
            // Arrange - create the mock repository
            Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
            mock.Setup(m => m.Schedules).Returns(new Schedule[] {
            
            });
            // Arrange - create the controller
            AdminScheduleController target = new AdminScheduleController(mock.Object, null, null);
            // Act
            Schedule result = (Schedule)target.ScheduleEdit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange - create mock repository
            Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
            // Arrange - create the controller
            AdminScheduleController target = new AdminScheduleController(mock.Object, null, null);
            // Arrange - create a Schedule
            Schedule Schedule = new Schedule { Id = 1 };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");
            // Act - try to save the Schedule

            ActionResult result = target.ScheduleEdit(Schedule);
            // Assert - check that the repository was not called
            mock.Verify(m => m.SaveSchedule(It.IsAny<Schedule>()), Times.Never());
            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }



        [TestMethod]
        public void Can_Delete_Valid_Schedules()
        {
            // Arrange - create a Schedule
            Schedule prod = new Schedule { Id = 2 };
            // Arrange - create the mock repository
            Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
            mock.Setup(m => m.Schedules).Returns(new Schedule[] {
            new Schedule {Id = 1},
            prod,
            new Schedule {Id = 3},
            });
            // Arrange - create the controller
            AdminScheduleController target = new AdminScheduleController(mock.Object, null, null);
            // Act - delete the Schedule
            target.Delete(prod.Id);
            // Assert - ensure that the repository delete method was
            // called with the correct Schedule
            mock.Verify(m => m.DeleteSchedule(prod.Id));

        }
    }

}
