using System;
using System.Collections.Generic;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
			p.Execute();
        }

		public void Execute()
		{
			List<ForumPost> posts = new List<ForumPost>();
			// We can create lots of 'em because we only have one instance of the UserProfileData among the lot.
			for (int j = 0; j < 100000; j++)
				posts.Add(new ForumPost($"This is message number {j.ToString()}.", DateTime.Now));

			posts.ForEach(p => Console.WriteLine(p.ToString()));
				
		}
	}


	// This is the big data which is expensive and unnecesary to replicate.
	// It is the flyweight.
	public class UserProfileData
	{
		public string Username { get; set; }
		public DateTime JoinDate { get; set; }
		public int Age { get; set; }
		// NO NO NO!  You can't do this.  The flyweight MUST BE IMMUTABLE.
		//public int PostCount { get; set; }
		public byte[] AvatarImage { get; set; }
	}

	public static class UserProfilePointer
	{
		public static readonly UserProfileData UserProfile = new UserProfileData
		{
			Username = "Phil",
			JoinDate = DateTime.Parse("01-01-2013"),
			Age = 101,
			AvatarImage = new byte[] { }	// Just pretend it's huge.  Giggity.
		};
	}


	public class ForumPost
	{
		// Members of this instance, exposed as properties.
		public string PostText { get; }
		public DateTime PostDate { get; }

		// Members of the flyweight, exposed as properties but not stored as copies in this object instance.
		public string Username => UserProfilePointer.UserProfile.Username;
		public int Age => UserProfilePointer.UserProfile.Age;
		public DateTime JoinDate => UserProfilePointer.UserProfile.JoinDate;
		public byte[] AvatarImage = UserProfilePointer.UserProfile.AvatarImage;
		
		public ForumPost(string postText, DateTime postDate)
		{
			this.PostText = postText;
			this.PostDate = postDate;
		}
	}

}
