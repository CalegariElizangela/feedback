using _2k_Survey.Core.Entities;

namespace _2k_Survey.Core.DAO.Interfaces.Repositories
{
    public interface IResponseRepository
    {
        Response GetResponse(int responseId);
        void Update(Response response);
    }
}
