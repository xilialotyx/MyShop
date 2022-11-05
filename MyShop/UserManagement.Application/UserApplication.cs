using _0_Framework.Application;
using UserManagement.Application.Contracts.User;
using UserManagement.Domain.UserAgg;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var user = _userRepository.Get(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            user.ChangePassword(password);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }

        public UserViewModel GetUserBy(long id)
        {
            var user = _userRepository.Get(id);
            return new UserViewModel()
            {
                Fullname = user.Fullname,
                Mobile = user.Mobile
            };
        }

        public OperationResult Register(RegisterUser command)
        {
            var operation = new OperationResult();

            if (_userRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var user = new User(command.Fullname, command.Username, password, command.Mobile, command.RoleId,
                picturePath);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditUser command)
        {
            var operation = new OperationResult();
            var user = _userRepository.Get(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_userRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            user.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, picturePath);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditUser GetDetails(long id)
        {
            return _userRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetBy(command.Username);
            if (user == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(user.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository.Get(user.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(user.Id, user.RoleId, user.Fullname
                , user.Username, user.Mobile, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<UserViewModel> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public List<UserViewModel> Search(UserSearchModel searchModel)
        {
            return _userRepository.Search(searchModel);
        }
    }
}