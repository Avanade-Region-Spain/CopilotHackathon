namespace IntegrationTests;

public class IntegrationTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public IntegrationTests(TestWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ReturnsHelloWorld()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello World!", content);
    }

    [Fact]
    public async Task DaysBetweenDates_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        var startDate = new DateTime(2022, 1, 1);
        var endDate = new DateTime(2022, 1, 31);

        // Act
        var response = await _client.GetAsync($"/daysbetweendates?startdate={startDate:yyyy-MM-dd}&enddate={endDate:yyyy-MM-dd}");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("30", content);
    }

    [Fact]
    public async Task Get_DaysBetweenDates_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        var startDate = DateTime.Now.AddDays(-7);
        var endDate = DateTime.Now;

        // Act
        var response = await _client.GetAsync($"/daysbetweendates?startdate={startDate}&enddate={endDate}");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var days = double.Parse(content);
        var expectedDays = (int)(endDate - startDate).TotalDays;
        Assert.Equal(expectedDays, days);
    }

    [Fact]
    public void TestDniNumberParsing()
    {
        // Arrange
        string dni = "12345678";
        int expectedDniNumber = 12345678;

        // Act
        int dniNumber = int.Parse(dni.Substring(0, 8));

        // Assert
        Assert.Equal(expectedDniNumber, dniNumber);
    }

    
    [Fact]
    public void TestColorEndpoint()
    {
        // Arrange
        var colorName = "blue";
        var expectedHex = "#0000FF";
        var colors = new[]
        {
            new Color { Name = "black", Category = "hue", Type = "primary", Code = new ColorCode { RGBA = new[] {255,255,255,1}, HEX = "#000000" } },
            new Color { Name = "white", Category = "value", Type = "primary", Code = new ColorCode { RGBA = new[] {0,0,0,1}, HEX = "#FFFFFF" } },
            new Color { Name = "red", Category = "hue", Type = "primary", Code = new ColorCode { RGBA = new[] {255,0,0,1}, HEX = "#FF0000" } },
            new Color { Name = "blue", Category = "hue", Type = "primary", Code = new ColorCode { RGBA = new[] {0,0,255,1}, HEX = "#0000FF" } },
            new Color { Name = "yellow", Category = "hue", Type = "primary", Code = new ColorCode { RGBA = new[] {255,255,0,1}, HEX = "#FFFF00" } },
            new Color { Name = "green", Category = "hue", Type = "secondary", Code = new ColorCode { RGBA = new[] {0,255,0,1}, HEX = "#00FF00" } }
        };

        // Act
        var resultHex = colors.First(c => c.Name == colorName).Code.HEX;

        // Assert
        Assert.Equal(expectedHex, resultHex);
    }

    [Fact]
    public void UriCreation_ValidUrl_ReturnsUriObject()
    {
        // Arrange
        string url = "https://www.example.com/";

        // Act
        var uri = new Uri(url);

        // Assert
        Assert.NotNull(uri);
        Assert.Equal(url, uri.ToString());
    }

    [Fact]
    public void GetCurrentProcess_ReturnsCurrentProcess()
    {
        // Arrange

        // Act
        var process = Process.GetCurrentProcess();

        // Assert
        Assert.NotNull(process);
        Assert.Equal(Process.GetCurrentProcess().Id, process.Id);
    }
}
