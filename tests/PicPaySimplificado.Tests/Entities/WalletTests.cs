using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Tests.Entities;

public class WalletTests
{
    
    [Fact]
    public void Should_Throw_Exception_in_Whithdraw_When_Balance_Is_Not_Enough()
    {
        //act
        var wallet = new Wallet("", "", "", "", "");
        
        //arrange && assert 
        Assert.Throws<ApplicationException>(() => wallet.SubtractBalance(10));
    }
    
    [Fact]
    public void Should_Return_Correct_Balance_When_Execute_Withdraw()
    {
        //act
        decimal expected = 10;
            
        var wallet = new Wallet("", "", "", "", "");
        wallet.AddBalance(20);
        
        //arrange
        wallet.SubtractBalance(10);
        var result = wallet.Balance;
        //assert
        Assert.Equal(expected,result);
    }

    public void Should_Add_Balance_To_Wallet_When_Execute_Deposit()
    {
        //act
        decimal expected = 20;
        var wallet = new Wallet("", "", "", "", "");
        
        //arrange
        wallet.AddBalance(20);
        var result = wallet.Balance;    

        //assert
        Assert.Equal(expected,result);
    }
    
    
}