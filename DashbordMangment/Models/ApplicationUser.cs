using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace DashbordMangment.Models
{


	[CollectionName("Users")]
	public class ApplicationUser : MongoIdentityUser<Guid>
	{
	}
}
