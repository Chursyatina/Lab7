using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolverApi : ControllerBase
    {
        private readonly ISolver _solver;

        public SolverApi(ISolver solver)
        {
            _solver = solver;
        }

        [HttpPost(Name = "Solver")]
        public double[] GetResult(InputData inputData)
        {
            var row = new List<String>();

            row.AddRange(inputData.Flows.Select(f => f.From).ToList());
            row.AddRange(inputData.Flows.Select(f => f.Into).ToList());

            row = new HashSet<string>(row).ToList();
            row.Remove("none");
            var matrixA = new double[row.Count + inputData.SpecialConditions.Count, inputData.Flows.Count];

            foreach (var item in inputData.Flows)
            {
                if (item.From != "none")
                {
                    matrixA[row.IndexOf(item.From), inputData.Flows.IndexOf(item)] = -1;
                }
                if (item.Into != "none")
                {
                    matrixA[row.IndexOf(item.Into), inputData.Flows.IndexOf(item)] = 1;
                }
            }

            for (int i = 0; i < inputData.SpecialConditions.Count; i++)
            {
                var condition = inputData.SpecialConditions[i];
                matrixA[row.Count + i, condition.FirstFlow - 1] = -1;
                matrixA[row.Count + i, condition.SecondFlow - 1] = condition.TimesMore;
            }

            var data = new Data()
            {
                MatrixA = matrixA,
                VectorY = new double[row.Count + inputData.SpecialConditions.Count],
                Tolerance = inputData.Flows.Select(f => f.Tolerance).ToArray(),
                VectorI = inputData.Flows.Select(f => f.IsEnabled ? 1.0 : 0.0).ToArray(),
                VectorX0 = inputData.Flows.Select(f => f.Value).ToArray()
            };

            return _solver.Solve(data);
        }
    }
}

/*
 * input data
 * {
  "flows": [
    {
      "from": "none",
      "into": "1",
      "value": 10.005,
      "isEnabled": true,
      "tolerance": 0.200
    },
    {
      "from": "1",
      "into": "none",
      "value": 3.033,
      "isEnabled": true,
      "tolerance": 0.121
    },    {
      "from": "1",
      "into": "2",
      "value": 6.831,
      "isEnabled": true,
      "tolerance": 0.683
    },    {
      "from": "2",
      "into": "none",
      "value": 1.985,
      "isEnabled": true,
      "tolerance": 0.040
    },    {
      "from": "2",
      "into": "3",
      "value": 5.093,
      "isEnabled": true,
      "tolerance": 0.102
    },    {
      "from": "3",
      "into": "none",
      "value": 4.057,
      "isEnabled": true,
      "tolerance": 0.081
    },    {
      "from": "3",
      "into": "none",
      "value": 0.991,
      "isEnabled": true,
      "tolerance":0.020
    },    {
      "from": "3",
      "into": "none",
      "value": 6.667,
      "isEnabled": true,
      "tolerance": 0.667
    }
  ],
  "specialConditions": [
    {
      "firstFlow": 1,
      "secondFlow": 2,
      "timesMore": 10
    }
  ]
}

real answer: [
  10.856608590281239,
  1.101564345139908,
  7.091179863182334,
  1.9697107272731023,
  5.121469135909233,
  3.976351138759706,
  0.9860831360316845,
  2.663864381959
]
 */