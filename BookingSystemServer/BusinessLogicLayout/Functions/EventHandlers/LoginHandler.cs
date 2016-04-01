using System.Linq;
using BusinessLogicLayout.Functions.DataHandlers;
using EntityModels.DataTransferObject;


namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class LoginHandler : EntityHandler
    {
        private readonly UpdateHandler _updateHandler;
        public LoginHandler()
        {
            _updateHandler = new UpdateHandler(UnitOfWork);
        }
        public UserDTO TryLogin(string email, string password)
        {
            var user = UnitOfWork.UserRepository.Get(x => x.Email == email).FirstOrDefault();
            if (user == null) return null;
            var hashedPassword = password.GenerateHash(user.Salt);

            return hashedPassword != user.Password ? null
            : _updateHandler.UpdateLastLoggedIn(user).ConvertToUserDto();
        }

    }
}