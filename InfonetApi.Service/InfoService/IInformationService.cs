using InfonetApi.Data.Entities;
using InfonetApi.Repository.InfoRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfonetApi.Service.InfoService
{
    public interface IInformationService
    {
        Task<ICollection<Infonet>> GetInformationList();
        Task<Infonet> GetInformation(int id);
        Task<Infonet> CreateInformation(Infonet infonet);

        Task<string> DeleteInformation(int id);
        Task<string> UpdateInformation(int id, Infonet infonet);
    }
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository _repository;

        public InformationService(IInformationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Infonet> CreateInformation(Infonet infonet)
        {
            try
            {
                var res = await _repository.CreateInformation(infonet);
                return res;
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
                var res = await _repository.DeleteInformation(id);
                return res;
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
                var res = await _repository.GetInformation(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Infonet>> GetInformationList()
        {
            try
            {
                var res = await _repository.GetInformationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateInformation(int id, Infonet infonet)
        {
            try
            {
                var res = await _repository.UpdateInformation(id,infonet);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
