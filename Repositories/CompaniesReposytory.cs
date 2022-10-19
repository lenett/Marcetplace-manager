using Microsoft.AspNetCore.Identity;
using MM.Areas.Identity.Models;
using MM.Data;

namespace MM.Repositories
{
    public interface ICompanies
    {
        public Task<List<Companies>> GetCompaniesByUserIdAsybc(string userId);
        public Task AddCompany(Companies company, HttpContext httpContext);
        public Task<List<Companies>> GetCurrentCompanies(HttpContext httpContext);

    }

    public class CompaniesReposytory : ICompanies
    {

        private readonly ApplicationDbContext _context;
        private readonly IUser _iUser;

        public CompaniesReposytory(ApplicationDbContext context, IUser iUser)
        {
            _context = context;
            _iUser = iUser;
        }

        public async Task<List<Companies>> GetCompaniesByUserIdAsybc(string currentUserID)
        {
            return _context.Companies.Where(b => b.UserId == currentUserID).ToList();
        }

        public async Task AddCompany(Companies company, HttpContext httpContext)
        {
            company.UserId = await _iUser.GetCurrentUserIdAsync(httpContext);
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Companies>> GetCurrentCompanies(HttpContext httpContext)
        {
            string currentUserID = await _iUser.GetCurrentUserIdAsync(httpContext);
            return _context.Companies.Where(b => b.UserId == currentUserID).ToList();
        }
    }

}
