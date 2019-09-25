namespace BusinessLogicLayer.User
{
    using BusinessLogicLayer.Currency;
    using BusinessLogicLayer.Role;
    using DataAccessLayer;
    using Server.Infrastructure.Dto;
    using Server.Infrastructure.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserLogic
    {
        public List<UserDto> GetAllUser()
        {
            List<UserDto> list =new List<UserDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var userList = db.User.AsEnumerable().ToList();

                foreach (var temp in userList)
                {
                    list.Add(new UserDto
                    {
                        Id = temp.Id,
                        Name = temp.Name,
                        Phone = temp.Phone,
                        Email = temp.Email,
                        Token = temp.Token,
                        RoleId = temp.RoleId,
                        RoleName = db.Role.First(x => x.Id == temp.RoleId).Key
                    });
                }
            }

            return list;
        }

        public User GetUserByPasswordAndEmail(string password, string email)
        {
            User result;

            string hashPassword = HashPassword(password, password);
          
            using (var db = new TimeTrackerModelContainer())
            {
                result = db.User.First(x => x.Password == hashPassword && x.Email == email);
            }

            return result;
        }

        public User GetUserbyEmail(string email)
        {
            User user;
            var result = new UserDto();
           
            using (var db = new TimeTrackerModelContainer())
            {
                user = db.User.First(x => x.Email == email);
            }

                return user;
        }

        public object AddClient(string name, string email, string password, string phone, object token, long teamId, string website)
        {
            throw new NotImplementedException();
        }

        public User AddUser(string name, string email, string password, string token, string phone)
        {
            string hashPassword = HashPassword(password, password);
            var roleLogic = new RoleLogic();
            var newUser = new User();
            var newTeam = new Team();
            var currencyLogic = new CurrencyLogic();
            var newUserTeamLink = new UserTeamLink();

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string newToken = Convert.ToBase64String(time.Concat(key).ToArray());

            var defaultUserRole = roleLogic.GetRole(Roles.User);
           
            var defautCurrency = currencyLogic.GetCurrencyByCode("HUF");

            using (var db = new TimeTrackerModelContainer())
            {
                var userInDb = db.User.FirstOrDefault(x => x.Email == email);

                if (userInDb != null)
                {
                    throw new Exception("Ez az Email cím már regisztrált");
                }

                newUser.Name = name;
                newUser.Email = email;
                newUser.Password = hashPassword;
                newUser.Phone = phone;
                newUser.Token = newToken;
                newUser.Role = defaultUserRole;
  
                db.Role.Attach(newUser.Role);
                db.User.Add(newUser);

                newTeam.Name = newUser.Name;

                db.Team.Add(newTeam);

                newUserTeamLink.User = newUser;
                newUserTeamLink.Currency= defautCurrency;
                newUserTeamLink.PrivatePrice = "0";
                newUserTeamLink.PublicPrice = "0";
                newUserTeamLink.Team = newTeam;

                db.Currency.Attach(newUserTeamLink.Currency);

                db.UserTeamLink.Add(newUserTeamLink);

                db.SaveChanges();
            }

            return newUser;
        }

        public Client AddClient(string name, string email, string password, string phone, string token, long teamId, string website)
        {
            string hashPassword = HashPassword(password, password);
            var newClient = new Client();

            var roleLogic = new RoleLogic();
            var newUser = new User();

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string newToken = Convert.ToBase64String(time.Concat(key).ToArray());

            var defaultUserRole = roleLogic.GetRole(Roles.Client);

            using (var db = new TimeTrackerModelContainer())
            {
                var team = db.Team.First(x => x.Id == teamId);

                var userInDb = db.User.FirstOrDefault(x => x.Email == email);

                if (userInDb != null)
                {
                    throw new Exception("Sikertelen regisztráció!");
                }

                newUser.Name = name;
                newUser.Email = email;
                newUser.Password = hashPassword;
                newUser.Phone = phone;
                newUser.Token = newToken;
                newUser.Role = defaultUserRole;

                db.Role.Attach(newUser.Role);
                db.User.Add(newUser);

                newClient.User = newUser;
                newClient.Website = website;
                newClient.TeamId = team.Id;

                db.Client.Add(newClient);

                db.SaveChanges();
            }

            return newClient;
        }

        public string HashPassword(string password, string salt)
        {
            var combinedPassword = String.Concat(password, salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public User ForgotPwd(string email)
        {
            User result;

            using (var db = new TimeTrackerModelContainer())
            {
                result = db.User.First(x => x.Email == email);
            }

            return result;
        }

        public User ResetPassword(string email, string password)
        {
            User user;
            using (var db = new TimeTrackerModelContainer())
            {
                user = db.User.First(x => x.Email == email);
                user.Password = HashPassword(password, password);
                db.User.AddOrUpdate(user);
                // todo: 
                db.SaveChanges();

                return user;
            }
        }

        public bool DeleteUserFromTeam(long id)
        {
            bool flag = false;
            UserTeamLink userTeamLink;

            using (var db = new TimeTrackerModelContainer())
            {
                userTeamLink = db.UserTeamLink.First(x => x.Id == id);
                db.UserTeamLink.Remove(userTeamLink);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public bool EditUser(long id, string name, string email, string password, string phone, long roleId)
        {
            User newUser;
           // bool flag = false;
            string hashPassword = password;

            using (var db = new TimeTrackerModelContainer())
            {
                newUser = db.User.First(x => x.Id == id);
                //var role = db.Role.First(x=>x.Id == )

                if (password != null)
                {
                    newUser.Password = HashPassword(hashPassword, password);
                }

                if (roleId != 0)
                {
                    newUser.RoleId = roleId;
                }

                newUser.Id = id;
                newUser.Name = name;
                newUser.Phone = phone;
                
                db.Entry(newUser).State = EntityState.Modified;

                db.SaveChanges();

                //flag = true;
            }

            return true;
        }

        public bool DeleteUser(long id)
        {
            bool flag = false;
            User user;

            using (var db = new TimeTrackerModelContainer())
            {
                var userTeamLink = db.UserTeamLink.First(x => x.UserID == id);
                user = db.User.First(x => x.Id == id);
                db.UserTeamLink.Remove(userTeamLink);
                db.User.Remove(user);
                db.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public UserDto GetUserById(long id)
        {
            UserDto user=new UserDto();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.User.First(x => x.Id == id);
                user.Id = result.Id;
                user.Name = result.Name;
                user.Email = result.Email;
                user.Phone = result.Phone;
                user.RoleId = result.RoleId;
                user.RoleName = db.Role.First(x => x.Id == user.RoleId).Key;
            }

            return user;
        }
    }
}