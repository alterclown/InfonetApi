using InfonetApi.Data.DbContexts;
using InfonetApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InfonetApi.Repository.InfoRepository
{
    public interface IInformationRepository
    {
        Task<ICollection<Infonet>> GetInformationList();
        Task<Infonet> GetInformation(int id);
        Task<Infonet> CreateInformation(Infonet infonet);

        Task<string> DeleteInformation(int id);
        Task<string> UpdateInformation(int id,Infonet infonet);
    }
    public class InformationRepository : IInformationRepository
    {
        private readonly InfonetContext _context;

        public InformationRepository(InfonetContext context)
        {
            _context = context;
        }
        public async Task<Infonet> CreateInformation(Infonet infonet)
        {
            try
            {
                //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(infonet.ResumeUpload);
                _context.Infonets.Add(infonet);
                await _context.SaveChangesAsync();
                return infonet;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteInformation(int id)
        {
            try
            {
                var response = await _context.Infonets.FindAsync(id);
                _context.Infonets.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Infonet> GetInformation(int id)
        {
            try
            {
                var res = await _context.Infonets.FirstOrDefaultAsync(m => m.InformationId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Infonet>> GetInformationList()
        {
            var response = from c in _context.Infonets
                           orderby c.InformationId descending
                           select c;
            return await response.ToListAsync();
        }

        public async Task<string> UpdateInformation(int id, Infonet infonet)
        {
            try
            {
                var res = await _context.Infonets.FirstOrDefaultAsync(m => m.InformationId == id);
                res.Name = infonet.Name;
                res.Country = infonet.Country;
                res.City = infonet.City;
                res.LanguageSkills = infonet.LanguageSkills;
                res.DateOfBirth = infonet.DateOfBirth;
                res.ResumeUpload = infonet.ResumeUpload;
                 _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
