using Microsoft.AspNetCore.Mvc;
using Repo.Framework;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IRepository<PersonEntity> _repository;

        public PersonController(IRepository<PersonEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<PersonEntity>> Get()
        {
            return _repository.GetItems();
        }


        [HttpPost]
        public async Task<PersonEntity> Post(PersonDto value)
        {
            return await _repository.InsertAsync(new PersonEntity(value.FirstName, value.LastName));
        }


        [HttpPut("{id}")]
        public async Task<PersonEntity> Update(Guid id, PersonEntity value)
        {
            if (id != value.Id)
                throw new Exception();

            return await _repository.UpdateAsync(new PersonEntity(value.FirstName, value.LastName) { Id = value.Id });
        }
    }
}
