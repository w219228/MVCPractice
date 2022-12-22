using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.Services
{
    public interface IMemberRepository
    {
        void Create(MemberCreateDTO dto);
		Member FindByAccount(string account);

	}
}
