using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interface;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext _context;
        public BillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBillAsync(Bill bill)
        {
            var currentBill = await _context.Bills.FirstOrDefaultAsync(b => b.BillID == bill.BillID);
            if (currentBill != null)
            {
                throw new InvalidOperationException($"Bill with ID {bill.BillID} already exists.");
            }
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task<Bill> GetBillByIdAsync(Guid billId)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.BillID == billId);
            if (bill != null)
            {
                return bill;
            }
            else
            {
                throw new KeyNotFoundException($"Bill with ID {billId} not found");
            }
        }

        public async Task<Bill> GetBillByEnrollmentIdAsync(Guid enrollmentId)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.EnrollmentID == enrollmentId);
            if (bill != null)
            {
                return bill;
            }
            else
            {
                throw new KeyNotFoundException($"Bill with enrollment ID {enrollmentId} not found");
            }
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            var listBill = await _context.Bills.ToListAsync();
            if (listBill == null || listBill.Count == 0)
            {
                throw new KeyNotFoundException("No bill found");
            }
            return listBill;
        }
    }
}