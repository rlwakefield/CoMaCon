using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMACON.tests;

public class AuthorizationTests
{
    [Fact]
    public void TestSuccessfulAuthorization()
    {
        
    }

    [Fact]
    public void TestUnsuccessfulAuthorizationMissingUsername()
    {
        
    }

    [Fact]
    public void TestUnsuccessfulAuthorizationMissingPassword()
    {
        
    }

    [Fact]
    public void TestUnsuccessfulAuthorizationInvalidUsernamePassword()
    {

    }

    [Fact]
    public void TestUnsuccessfulAuthorizationMultipleUsersSameUsernamePassword()
    {

    }

    [Fact]
    public void TestSuccessfulVerifyTokenStillActive()
    {

    }

    [Fact]
    public void TestUnsuccessfulVerifyTokenStillActiveTokenDoesntExist()
    {

    }

    [Fact]
    public void TestUnsuccessfulVerifyTokenStillActiveTokenExpired()
    {

    } 
}
