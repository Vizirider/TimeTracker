using System;
using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogicLayer.Client
{
    using DataAccessLayer;
    using Server.Infrastructure.Dto.Responses;

    public class ClientLogic
    {
        public List<ClientDto> GetAllClient()
        {
            List<ClientDto> clientList = new List<ClientDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var list = db.Client.AsEnumerable().ToList();

                foreach (var tempList in list)
                {
                    clientList.Add(new ClientDto
                        {
                            Id = tempList.Id,
                            Website = tempList.Website,
                            TeamId = tempList.TeamId,
                            UserId = tempList.Id,
                            Name = tempList.User.Name
                        }
                    );
                }
            }

            return clientList;
        }

        public ClientDetailsResponse GetClientDetailsById(long id)
        {
            ClientDetailsResponse client = new ClientDetailsResponse();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Client.First(x => x.Id == id);

                client.Id = result.Id;
                client.TeamName = result.Team.Name;
                client.Website = result.Website;
                client.ClientName = result.User.Name;
                client.TeamId = result.TeamId;
            }

            return client;
        }

        public Client GetClientById(long id)
        {
            Client client;

            using (var db = new TimeTrackerModelContainer())
            {
                client = db.Client.First(x => x.Id == id);
            }

            return client;
        }

        public bool EditClient(long id, string website, long teamId, string clientName)
        {
            bool flag = false;

            Client client = new Client();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Client.First(x => x.Id == id);

                var user = db.User.First(x => x.Id == result.UserId);
                client.Id = result.Id;
                client.Website = website;
                client.TeamId = teamId;
                user.Name = clientName;
                client.UserId = user.Id;

                try
                {
                    var s = db.Set<Client>().Local.FirstOrDefault(x => x.Id == id);

                    if (s != null)
                    {
                        db.Entry(s).State = EntityState.Detached;
                    }

                    if (result.Id == id)
                    {
                        db.Entry(user).State = EntityState.Modified;
                        db.Entry(client).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }



                flag = true;

            }

            return flag;
        }

        public bool DeleteClient(long id)
        {
            bool flag = false;

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Client.First(x => x.Id == id);
                db.Client.Remove(result);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public List<ClientDto> GetAllClientByUser(string email)
        {
            var clientList = new List<ClientDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var user = db.User.First(x => x.Email == email);
                var innerTeamId = from t in db.UserTeamLink where t.UserID == user.Id select t.TeamId;
                var projectLis = from c in db.Client where innerTeamId.Contains(c.TeamId) select c;

                foreach (var temp in projectLis)
                {
                    clientList.Add(new ClientDto
                    {
                        Id = temp.Id,
                        Name = temp.User.Name
                    });
                }
            }

            return clientList;
        }

    }
}
