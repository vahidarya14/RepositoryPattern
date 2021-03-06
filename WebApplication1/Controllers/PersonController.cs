using _2_DomainEntities;
using _4_UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Repo.Framework;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IDbUnitOfWork _unitOfWork;

        public PersonController( IDbUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<PersonEntity>> Get()
        {
            return _unitOfWork.People.GetItems();
        }


        [HttpPost]
        public async Task<PersonEntity> Post(PersonDto value, CancellationToken ct)
        {
            var res= await _unitOfWork.People.InsertAsync(new PersonEntity(value.FirstName, value.LastName));
            await _unitOfWork.SaveChangesAsync(ct);
            return res;
        }



        [HttpPut("{id}")]
        public async Task<PersonEntity> Update(Guid id, PersonEntity value, CancellationToken ct)
        {
            if (id != value.Id)
                throw new Exception();

            var res =await _unitOfWork.People.UpdateAsync(new PersonEntity(value.FirstName, value.LastName) 
                                                        { Id = value.Id });
            await _unitOfWork.SaveChangesAsync(ct);
            return res;
        }
    }
}
