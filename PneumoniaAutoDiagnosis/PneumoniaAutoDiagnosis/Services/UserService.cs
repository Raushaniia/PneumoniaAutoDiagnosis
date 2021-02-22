using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace PneumoniaAutoDiagnosis.Services
{
	public class UserService : BaseDatabaseService
	{
		public IMongoCollection<User> _users;
		private readonly UserManager<IdentityUser> _userManager;

		public UserService(IDiagnosesDbDatabaseSettings settings) : base(settings)
		{
			_users = Database.GetCollection<User>(settings.UsersCollectionName);
		}

		public List<User> Get() => _users.Find(p => true).ToList();
		public User Get(string userId) => _users.Find(u => u.Id == userId).FirstOrDefault();
		
		public async void CreateAsync(User user)
		{
			_users.InsertOne(user);
			//var newUser = new IdentityUser { UserName = user.Email, Email = user.Email };
			//var result = await _userManager.CreateAsync(newUser, user.Password);

		}
		public void Delete(string userId)
		{
			_users.DeleteOne(u => u.Id == userId);
		}
		public void Update(string id, User userUpdated) => _users.ReplaceOne(p => p.Id == id, userUpdated);
	}
}
