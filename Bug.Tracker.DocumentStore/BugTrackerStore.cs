using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using LiteDB;

namespace Bug.Tracker.DocumentStore
{
    public class BugTrackerStore
    {
        private static readonly LiteDatabase db = new LiteDatabase("BugTracker");

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> lstUsersToReturn = null;
            await Task.Run(() =>
            {
                var users = db.GetCollection<User>();
                var lstUsers = users.FindAll();

                var ieUsers = new List<User>();
                foreach (var user in lstUsers)
                {
                    ieUsers.Add(new User { Id = user.Id, Name = user.Name });
                }
                lstUsersToReturn = ieUsers;
            });
            return lstUsersToReturn;
        }

        public async Task<IEnumerable<BugItem>> GetBugs()
        {
            IEnumerable<BugItem> lstBugsToReturn = null;
            await Task.Run(() =>
            {
                var bugs = db.GetCollection<BugItem>();
                var lstBugs = bugs.FindAll();

                var ieBugs = new List<BugItem>();
                foreach (var bug in lstBugs)
                {
                    ieBugs.Add(new BugItem { Id = bug.Id, AssignedTo = bug.AssignedTo, DateCreated = bug.DateCreated, Status = bug.Status, Description = bug.Description, Title = bug.Title  });
                }
                lstBugsToReturn = ieBugs;
            });
            return lstBugsToReturn;
        }

        //public Task<User> FindItem<T>(Guid id) where T : RecordWithGuid
        //{
        //    return Task.Run(() => db.GetCollection<T>().Cast<RecordWithGuid>.FindOne(x => x.Id == id));
        //}

        public Task<BugItem> FindBug(Guid bugId)
        {
            return Task.Run(() => db.GetCollection<BugItem>().FindOne(x => x.Id == bugId));
        }

        public Task<User> FindUser(Guid userId)
        {
            return Task.Run(() => db.GetCollection<User>().FindOne(x => x.Id == userId));
        }
        public Task<User> FindUser(string name)
        {
            return Task.Run(() => db.GetCollection<User>().FindOne(x => x.Name == name));
        }

        public async Task<User> AddUser(string name)
        {
            User addedUser = null;
            await Task.Run(() =>
            {
                try
                {
                    var users = db.GetCollection<User>();

                    var user = users.FindOne(x => x.Name == name);
                    if (user != null)
                    {
                        throw new Exception($"User with name {user.Name} already exists!");
                    }
                    var newUser = new User(Guid.NewGuid()) { Name = name };
                    users.Insert(newUser);
                    addedUser = newUser;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while adding user with name {name}!", ex);
                }
            });
            return addedUser;
        }

        public async Task<User> UpdateUser(Guid id, string name)
        {
            User updatedUser = null;
                try
                {
                    var existingUser = await FindUser(id);
                    if (existingUser == null)
                    {
                        throw new Exception($"User with id {id} wasn't found!");
                    }
                    existingUser.Name = name;
                    db.GetCollection<User>().Update(existingUser);
                    updatedUser = existingUser;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while updating user with id {id}!", ex);
                }
            return updatedUser;
        }

        public async Task<BugItem> UpdateBug(Guid id, string status, string userId = null)
        {
            BugItem updatedBugItem = null;
            await Task.Run(() =>
            {
                try
                {
                    var bugs = db.GetCollection<BugItem>();
                    var existingBug = bugs.FindOne(x => x.Id == id);
                    if (existingBug == null)
                    {
                        throw new Exception($"Bug with id {id} wasn't found!");
                    }
                    Enum.TryParse(status, out Models.Enums.BugStatus newStatus);
                    existingBug.Status = newStatus;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        existingBug.AssignedTo = userId;
                    }
                    bugs.Update(existingBug);
                    updatedBugItem = existingBug;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while updating bug with id {id}!", ex);
                }
            });
            return updatedBugItem;
        }

        public async Task<BugItem> AddBug(string title, string description)
        {
            BugItem addedBugItem = null;
            await Task.Run(() =>
            {
                try
                {
                    var bugs = db.GetCollection<BugItem>();

                    var bug = new BugItem
                    {
                        Title = title,
                        Description = description
                    };
                    if (bugs.FindOne(x => x.Title == bug.Title) != null)
                    {
                        throw new Exception($"Bug with title {bug.Title} already exists!");
                    }
                    bugs.Insert(bug);
                    addedBugItem = bug;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while adding bug with title {title}!", ex);
                }
            });
            return addedBugItem;
        }
    }
}
