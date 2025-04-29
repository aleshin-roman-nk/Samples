
using DtoNullLesson;
using System.Text.Json;

var updateUserDto = new UserUpdateDto
{
	Id = 1,
	Name = "Roman",
};

string json = JsonSerializer.Serialize(updateUserDto);
Console.WriteLine(json);