using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HangSanXuatApiController : ControllerBase
    {
        private readonly Webbanhang _context;

        public HangSanXuatApiController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/NhaCungCaPAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangSanXuatModel>>> GetHangSanXuatModel()
        {
            return await _context.HangSanXuat.ToListAsync();
        }

        // GET: api/NhaCungCaPAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HangSanXuatModel>> GetHangSanXuatModel(int id)
        {
            var hangsanxuatModel = await _context.HangSanXuat.FindAsync(id);

            if (hangsanxuatModel == null)
            {
                return NotFound();
            }

            return hangsanxuatModel;
        }

        // PUT: api/NhaCungCaPAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHangSanXuatModel(int id, HangSanXuatModel hangsanxuatModel)
        {
            if (id != hangsanxuatModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hangsanxuatModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangSanXuatModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NhaCungCaPAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HangSanXuatModel>> PostHangSanSanXuatModel(HangSanXuatModel hangsanxuatModel)
        {
            _context.HangSanXuat.Add(hangsanxuatModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHangSanXuatModel", new { id = hangsanxuatModel.ID }, hangsanxuatModel);
        }

        // DELETE: api/NhaCungCaPAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HangSanXuatModel>> DeleteHangSanXuatModel(int id)
        {
            var hangsanxuatModel = await _context.HangSanXuat.FindAsync(id);
           

            _context.HangSanXuat.Update(hangsanxuatModel);
            await _context.SaveChangesAsync();

            return hangsanxuatModel;
        }

        private bool HangSanXuatModelExists(int id)
        {
            return _context.HangSanXuat.Any(e => e.ID == id);
        }
    }
}
