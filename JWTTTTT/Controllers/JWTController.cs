using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTTTTT.Controllers
{
	/* 
	 * JWT Token Terrible Test Tool 
	 * 
	 * author : susilonurcahyo@gmail.com
	 * for testing purposes only,
	 * don't use in production, because it's terrible.
	 */

	/*
	 * from example at :
	 * https://dotnetcoretutorials.com/2020/01/15/creating-and-validating-jwt-tokens-in-asp-net-core/
	 */

	public class JWTController : Controller
    {
		private string myIssuer = "http://tokenissuer.com";
		private string myAudience = "http://tokenaudience.com";
		private SymmetricSecurityKey securityKey()
		{			
			var mySecret = "34.w7YRTEy9,3JJz&m/}=*a";
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
		}

		[HttpGet]        
        public string Get(string userId)
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				// change with your own claim
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
					new Claim(ClaimTypes.Email, "susilonurcahyo@gmail.com"),
					new Claim(ClaimTypes.Role, "poorgrammer"),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = myIssuer,
				Audience = myAudience,
				SigningCredentials = new SigningCredentials(securityKey(), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
        }

        [HttpGet]        
        public bool Verify(string token)
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = myIssuer,
					ValidAudience = myAudience,
					IssuerSigningKey = securityKey()
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}

		[HttpGet]
		public string GetClaim(string token, string claimType)
		{
			if (Verify(token))
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

				var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
				return stringClaimValue;
			} else
			{
				return "Invalid Token!";
			}
		}
	}
}
