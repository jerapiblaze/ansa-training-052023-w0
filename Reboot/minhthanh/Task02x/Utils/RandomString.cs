using System;
namespace Task02x.Utils;

public class RandomString{
    private static Random rand = new Random();
    private static string lowercases = "abcdefghijklmnopqrstuvwxyz";
    private static string uppercases = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static string numeric = "0123456789";
    public static string GenerateString(int strlen = 0, bool lower = true, bool upper = true, bool num = true){
        rand = new Random();
        string dictionary = "";
        if (strlen == 0)
        {
            strlen = rand.Next(6, 10);
        }
        if (lower)
        {
            dictionary += lowercases;
        }
        if (upper)
        {
            dictionary += uppercases;
        }
        if (num)
        {
            dictionary += numeric;
        }
        if (dictionary.Length == 0)
        {
            dictionary += "RANDOM";
        }
        string str = "";
        for (int i = 0; i < strlen; i++){
            var randValue = rand.Next(0, dictionary.Length);
            str += dictionary[randValue];
        }
        return str;
    }
}