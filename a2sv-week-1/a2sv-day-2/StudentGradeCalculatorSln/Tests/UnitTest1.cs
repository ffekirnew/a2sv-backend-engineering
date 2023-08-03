namespace Tests;

public class TestStudentGradeCalculator
{
    [Fact]
    public void TestAddSubject_ValidInput()
    {
        var calculator = new StudentGradeCalculator("Fikernew", 3);

        Assert.Equal(calculator.AddSubject("OOP", 97), 0);
    }
    
    
    [Fact]
    public void TestAddSubject_InvalidInput()
    {
        var calculator = new StudentGradeCalculator("Fikernew", 3);

        calculator.AddSubject("OOP", 10);
        Assert.Equal(calculator.AddSubject("OOP", 97), -1);
    }
}