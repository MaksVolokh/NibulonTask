using Microsoft.AspNetCore.Mvc;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;

namespace NibulonTask.Controllers
{
    public class TablesController : Controller
    {
        private readonly IGrainElevatorArrivalsTableService _grainService;
        private readonly IGroupedDataTableService _dataService;
        private readonly IWeightedAverageTableService _weightedService;
        
        public TablesController(IGrainElevatorArrivalsTableService grainService, IGroupedDataTableService dataService, IWeightedAverageTableService weightedService)
        {
            _grainService = grainService;
            _dataService = dataService;
            _weightedService = weightedService;
        }


        [HttpGet("GrainElevatorArrivalsTable/{id}")]
        public async Task<ActionResult<GrainElevatorArrivalsTableDTO>> GetGrainElevatorArrivalsTableByIdAsync(int id)
        {
            var table = await _grainService.GetGrainElevatorArrivalsTableByIdAsync(id);

            if (table == null)
            {
                return NotFound("Table is not found");
            }

            return View(table);
        }


        [HttpPost("GrainElevatorArrivalsTable")]
        public async Task<ActionResult<GrainElevatorArrivalsTableDTO>> AddOrUpdateGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTableDTO tableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _grainService.AddOrUpdateGrainElevatorArrivalsTableAsync(tableDto);

            return Ok();
        }


        [HttpDelete("GrainElevatorArrivalsTable/{id}")]
        public async Task<ActionResult> DeleteGrainElevatorArrivalsTableAsync(int id)
        {
            var table = await _grainService.GetGrainElevatorArrivalsTableByIdAsync(id);

            if (table == null)
            {
                return NotFound("Table is not found");
            }

            await _grainService.DeleteGrainElevatorArrivalsTableAsync(id);

            return NoContent();
        }


        [HttpGet("GroupedDataTable/{id}")]
        public async Task<ActionResult<GroupedDataTableDTO>> GetGroupedDataTableByIdAsync(int tableId)
        {
            var table = await _dataService.GetGroupedDataTableByIdAsync(tableId);

            if (table == null)
            {
                return NotFound("Table is not found!");
            }

            return View(table);
        }


        [HttpPost("GroupedDataTable/{date}")]
        public async Task<ActionResult> UpdateGroupedDataTableAsync(GroupedDataTableDTO tableDTO)
        {
            await _dataService.UpdateGroupedDataTableAsync(tableDTO);

            return Ok();
        }


        [HttpGet("WeightedAverageTable/{date}")]
        public async Task<ActionResult<WeightedAverageTableDTO>> GetWeightedAverageTableByIdAsync(int id)
        {
            var table = await _weightedService.GetWeightedAverageTableByIdAsync(id);

            if (table == null)
            {
                return NotFound("Table is not found!");
            }

            return View(table);
        }


        [HttpPost("WeightedAverageTable/{date}")]
        public async Task<ActionResult> UpdateWeightedAverageTableAsync(WeightedAverageTableDTO tableDTO)
        {
            await _weightedService.UpdateWeightedAverageTableAsync(tableDTO);

            return Ok(); 
        }
    }
}
