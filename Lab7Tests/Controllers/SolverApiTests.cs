using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab7.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Lab7.Controllers.Tests
{
    [TestClass()]
    public class SolverApiTests
    {
        private double accuracy = 0.1;

        [TestMethod()]
        public void First()
        {
            // Arrange
            ISolver solver = new Solver();

            SolverApi solverApi = new SolverApi(solver);

            double[] expectedResult = new double[] { 10.056, 3.014, 7.041, 1.982, 5.059, 4.067, 0.992 };

            InputData data = new InputData()
            {
                Flows = new List<Flow>()
                {
                    new Flow()
                    {
                      From= "none",
                      Into= "1",
                      Value= 10.005,
                      IsEnabled= true,
                      Tolerance= 0.200
                    },
                    new Flow()
                    {
                      From= "1",
                      Into= "none",
                      Value= 3.033,
                      IsEnabled= true,
                      Tolerance= 0.121
                    },
                    new Flow()
                    {
                      From="1",
                      Into= "2",
                      Value= 6.831,
                      IsEnabled= true,
                      Tolerance= 0.683
                    },
                    new Flow()
                    {
                      From= "2",
                      Into= "none",
                      Value= 1.985,
                      IsEnabled= true,
                      Tolerance= 0.040
                    },
                    new Flow()
                    {
                      From="2",
                      Into="3",
                      Value= 5.093,
                      IsEnabled= true,
                      Tolerance= 0.102
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 4.057,
                      IsEnabled= true,
                      Tolerance= 0.081
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 0.991,
                      IsEnabled= true,
                      Tolerance=0.020
                    },
                },
                SpecialConditions = new List<SpecialCondition>()
                {
                }
            };

            // Act
            var result = solverApi.GetResult(data);

            // Assert
            if (IsEqual(expectedResult, result))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void Second()
        {
            // Arrange
            ISolver solver = new Solver();

            SolverApi solverApi = new SolverApi(solver);

            double[] expectedResult = new double[] { 10.540, 2.836, 6.973, 1.963, 5.009, 4.020, 0.989, 0.731 };

            InputData data = new InputData()
            {
                Flows = new List<Flow>()
                {
                    new Flow()
                    {
                      From= "none",
                      Into= "1",
                      Value= 10.005,
                      IsEnabled= true,
                      Tolerance= 0.200
                    },
                    new Flow()
                    {
                      From= "1",
                      Into= "none",
                      Value= 3.033,
                      IsEnabled= true,
                      Tolerance= 0.121
                    },
                    new Flow()
                    {
                      From="1",
                      Into= "2",
                      Value= 6.831,
                      IsEnabled= true,
                      Tolerance= 0.683
                    },
                    new Flow()
                    {
                      From= "2",
                      Into= "none",
                      Value= 1.985,
                      IsEnabled= true,
                      Tolerance= 0.040
                    },
                    new Flow()
                    {
                      From="2",
                      Into="3",
                      Value= 5.093,
                      IsEnabled= true,
                      Tolerance= 0.102
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 4.057,
                      IsEnabled= true,
                      Tolerance= 0.081
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 0.991,
                      IsEnabled= true,
                      Tolerance=0.020
                    },
                    new Flow()
                    {
                      From= "1",
                      Into= "none",
                      Value= 6.667,
                      IsEnabled= true,
                      Tolerance= 0.667
                    }
                },
                SpecialConditions = new List<SpecialCondition>()
                {
                }
            };

            // Act
            var result = solverApi.GetResult(data);

            // Assert
            if (IsEqual(expectedResult, result))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void Third()
        {
            // Arrange
            ISolver solver = new Solver();

            SolverApi solverApi = new SolverApi(solver);

            double[] expectedResult = new double[] { 10.153, 2.978, 7.175, 1.978, 5.197, 3.962, 0.986, 0.249 };

            InputData data = new InputData()
            {
                Flows = new List<Flow>()
                {
                    new Flow()
                    {
                      From= "none",
                      Into= "1",
                      Value= 10.005,
                      IsEnabled= true,
                      Tolerance= 0.200
                    },
                    new Flow()
                    {
                      From= "1",
                      Into= "none",
                      Value= 3.033,
                      IsEnabled= true,
                      Tolerance= 0.121
                    },
                    new Flow()
                    {
                      From="1",
                      Into= "2",
                      Value= 6.831,
                      IsEnabled= true,
                      Tolerance= 0.683
                    },
                    new Flow()
                    {
                      From= "2",
                      Into= "none",
                      Value= 1.985,
                      IsEnabled= true,
                      Tolerance= 0.040
                    },
                    new Flow()
                    {
                      From="2",
                      Into="3",
                      Value= 5.093,
                      IsEnabled= true,
                      Tolerance= 0.102
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 4.057,
                      IsEnabled= true,
                      Tolerance= 0.081
                    },
                    new Flow()
                    {
                      From="3",
                      Into= "none",
                      Value= 0.991,
                      IsEnabled= true,
                      Tolerance=0.020
                    },
                    new Flow()
                    {
                      From= "3",
                      Into= "none",
                      Value= 6.667,
                      IsEnabled= true,
                      Tolerance= 0.667
                    }
                },
                SpecialConditions = new List<SpecialCondition>()
                {
                    new SpecialCondition()
                    {
                        FirstFlow= 1,
                        SecondFlow= 2,
                        TimesMore= 10
                    }
                }
            };

            // Act
            var result = solverApi.GetResult(data);

            // Assert
            if (IsEqual(expectedResult, result))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        private bool IsEqual(double[] first, double[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (Math.Abs(first[i] - second[i]) > accuracy)
                {
                    return false;
                }
            }
            return true;
        }
    }
}