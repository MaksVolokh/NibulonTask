using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Entities;

namespace NibulonTask.Controllers
{
    public class TableController : Controller
    {
        private readonly ITable1Service _table1Service;
        private readonly ITable2Service _table2Service;
        private readonly ITable3Service _table3Service;
        private readonly IMapper _mapper;

        public TableController(ITable1Service table1Service, ITable2Service table2Service, ITable3Service table3Service, IMapper mapper)
        {
            _table1Service = table1Service;
            _table2Service = table2Service;
            _table3Service = table3Service;
            _mapper = mapper;
        }

        [HttpGet("Table1")]
        public async Task<ActionResult<Table1DTO>> GetTable1ByIdAsync(int id)
        {
            var table1 = await _table1Service.GetTable1ByIdAsync(id);

            if (table1 == null)
            {
                return NotFound("Table is not created!");
            }

            var table1Dto = _mapper.Map<Table1DTO>(table1);

            return Ok(table1Dto);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Table1DTO>> AddOrUpdateTable1Async(Table1DTO table1Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var table1 = _mapper.Map<Table1>(table1Dto);

            var previousTable1 = await _table1Service.GetTable1ByIdAsync(table1.Id);

            var changes = GetTable1Changes(previousTable1, table1);

            await _table1Service.AddOrUpdateTable1Async(table1Dto);

            var updatedTable3 = _mapper.Map<Table3>(table1);
            updatedTable3.Changes = changes; 

            return Ok();
        }

        private string GetTable1Changes(Table1DTO previousTable1, Table1 updatedTable1)
        {
            var changes = new List<string>();

            var properties = typeof(Table1).GetProperties();

            foreach (var property in properties)
            {
                var previousValue = property.GetValue(previousTable1);
                var updatedValue = property.GetValue(updatedTable1);

                if (!Equals(previousValue, updatedValue))
                {
                    changes.Add($"{property.Name} = {previousValue} => {updatedValue}");
                }
            }

            return string.Join(", ", changes);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTable1Async(int id)
        {
            var deletedTable1 = await _table1Service.GetTable1ByIdAsync(id);

            if (deletedTable1 == null)
            {
                return NotFound("Table is not created");
            }

            await _table1Service.DeleteTable1Async(id);

            return NoContent();
        }

        [HttpGet("Table2")]
        public async Task<ActionResult<Table2DTO>> GetTable2ByDateAsync(DateTime date)
        {
            var table2 = await _table2Service.GetTable2ByDateAsync(date);

            if (table2 == null)
            {
                return NotFound("Table is not found!");
            }

            var table2Dto = _mapper.Map<Table2DTO>(table2);

            return Ok(table2Dto);
        }


        [HttpGet("Table3")]
        public async Task<ActionResult<Table3DTO>> GetTable3ByDateAsync(DateTime date)
        {
            var table3 = await _table3Service.GetTable3ByDateAsync(date);

            if (table3 == null)
            {
                return NotFound("Table is not found!");
            }

            var table3Dto = _mapper.Map<Table3DTO>(table3);

            return Ok(table3Dto);
        }

    }
}
