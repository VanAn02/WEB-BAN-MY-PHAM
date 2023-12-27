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
    public class KhachHangApiController : ControllerBase
    {
        private readonly Webbanhang _context;

        public KhachHangApiController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/UserApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHangModel>>> GetUserModel()
        {
            return await _context.KhachHang.ToListAsync();
        }

        // GET: api/UserApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHangModel>> GetUserModel(int id)
        {
            var userModel = await _context.KhachHang.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/UserApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, KhachHangModel userModel)
        {
            if (id != userModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/UserApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KhachHangModel>> PostUserModel(KhachHangModel userModel)
        {
            _context.KhachHang.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.ID }, userModel);
        }

        // DELETE: api/UserApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KhachHangModel>> DeleteUserModel(int id)
        {
            var userModel = await _context.KhachHang.FindAsync(id);
         

            _context.KhachHang.Update(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        private bool UserModelExists(int id)
        {
            return _context.KhachHang.Any(e => e.ID == id);
        }
    }
}
