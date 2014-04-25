using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using Brain.Domain.Models;

namespace Brain.Domain.Repositories
{
	public class RepRepository : IRepRepository
	{
		#region Fields

		private DNRmanageEntities _dataContext;

		#endregion

		#region Constructors

		public RepRepository(DNRmanageEntities dataContext)
		{
			_dataContext = dataContext;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets a company rep by repId
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		public companyRep GetCompanyRep(int repId)
		{
			return _dataContext.companyReps.SingleOrDefault(x => x.repId == repId);
		}

		/// <summary>
		/// Get a company rep profile by repId
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		public companyRepProfile GetCompanyRepProfile(int repId)
		{
			return _dataContext.companyRepProfiles.SingleOrDefault(x => x.repId == repId);
		}

		/// <summary>
		/// Gets rep information and rep profile information by repId, but does not return the password with the set
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		public CompanyRepAndProfile GetCompanyRepAndProfile(int repId)
		{
			var companyRepAndProfile = (from rep in _dataContext.companyReps
				join profile in _dataContext.companyRepProfiles on rep.repId equals profile.repId
				select new CompanyRepAndProfile
				{
					RepId = rep.repId,
					RepFirstName = rep.rep_firstName,
					RepLastName = rep.rep_lastName,
					RepCellNumber = rep.rep_cellNum,
					RepEmail = rep.rep_email,
					LoginToken = rep.loginToken,
					CompanyRepProfileId = profile.companyRepProfileId,
					LastAuthentication = profile.lastAuthentication,
					NumberOfDaysTokenExpires = profile.tokenExpirationDays
				}).SingleOrDefault();

			return companyRepAndProfile;
		}

		/// <summary>
		/// Receives a username and an encrypted password, and attempts to authenticate user. If it fails, returns null. If it succeeds, returns the token needed to store in browser.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="hashedPassword"></param>
		public companyRep GetAuthenticatedUserByCredentials(string username, string hashedPassword)
		{
			var companyRep = (from rep in _dataContext.companyReps
				join profile in _dataContext.companyRepProfiles on rep.repId equals profile.repId
				where rep.rep_email == username
				where profile.companyRepPassword == hashedPassword
				select rep).FirstOrDefault();
			if (companyRep != null)
			{
				return companyRep;
			}
			return null;
		}

		/// <summary>
		/// Saves a login token by repId and loginToken.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="loginToken"></param>
		public void SaveLoginToken(long userId, string loginToken)
		{
			var rep = _dataContext.companyReps.SingleOrDefault(x => x.repId == userId);

			if (rep != null)
			{
				rep.loginToken = loginToken;
			}
		}

		#endregion
	}

	public interface IRepRepository
	{
		/// <summary>
		/// Gets a company rep by repId
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		companyRep GetCompanyRep(int repId);

		/// <summary>
		/// Get a company rep profile by repId
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		companyRepProfile GetCompanyRepProfile(int repId);

		/// <summary>
		/// Gets rep information and rep profile information by repId, but does not return the password with the set
		/// </summary>
		/// <param name="repId"></param>
		/// <returns></returns>
		CompanyRepAndProfile GetCompanyRepAndProfile(int repId);

		/// <summary>
		/// Receives a username and an encrypted password, and attempts to authenticate user. If it fails, returns null. If it succeeds, returns the token needed to store in browser.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="hashedPassword"></param>
		companyRep GetAuthenticatedUserByCredentials(string username, string hashedPassword);

		/// <summary>
		/// Saves a login token by repId and loginToken.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="loginToken"></param>
		void SaveLoginToken(long userId, string loginToken);
	}
}