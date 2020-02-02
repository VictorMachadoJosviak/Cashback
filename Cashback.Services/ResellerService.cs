using AutoMapper;
using Cashback.Domain.Entities;
using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.DTO.Reseller;
using Cashback.Infra.Extensions;
using Cashback.Infra.Helpers;
using Cashback.Repository.Interfaces;
using Cashback.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Services
{
    public class ResellerService : IResellerService
    {
        private readonly IResellerRepository _resellerRepository;
        private readonly IMapper _mapper;
        public ResellerService(IResellerRepository resellerRepository, IMapper mapper)
        {
            _resellerRepository = resellerRepository;
            _mapper = mapper;
        }

        public async Task<ResellerDTO> CreateReseller(CreateResellerDTO reseller)
        {
            var newReseller = new Reseller
            {
                Email = reseller.Email,
                LastName = reseller.LastName,
                Name = reseller.Name,
                Password = reseller.Password.ToHash(),
                CPF = reseller.CPF.RemoveCpfMask()
            };
            var created = _resellerRepository.Add(newReseller);
            return _mapper.Map<ResellerDTO>(created);
        }

        public async Task<ResellerDTO> Authenticate(CredentialsDTO credentials)
        {
            var reseller = _resellerRepository.FindBy(x => x.Email == credentials.Email);
            if (reseller != null)
            {
                var verified = credentials.Password.VerifyHash(reseller.Password);
                if (verified)
                {
                    return _mapper.Map<ResellerDTO>(reseller);
                }
            }
            return null;
        }

        public async Task<bool> CPFNotExists(string cpf)
        {
            return !_resellerRepository.Exists(x => x.CPF == cpf);
        }

        public async Task<bool> EmailNotExists(string email)
        {
            return !_resellerRepository.Exists(x => x.Email == email);
        }
    }
}
