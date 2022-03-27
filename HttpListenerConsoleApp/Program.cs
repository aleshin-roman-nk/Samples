using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

List<string> _log = new List<string>();

var t = Listen();
t.Wait();

async Task Listen()
{
    HttpListener listener = new HttpListener();
    //listener.Prefixes.Add("http://127.0.0.0:5001/");
    listener.Prefixes.Add("http://localhost:5001/");
    //listener.Prefixes.Add("http://*:5001/");
    listener.Start();
    Console.WriteLine("Ожидание подключений...");

    var res = "";

    while (!res.Equals("/exit"))
    {
        HttpListenerContext context = await listener.GetContextAsync();
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        var now = DateTime.Now;

        //string responseString = $"<html><head><meta charset='utf8'></head><body>Привет мир! Сейчас {now.ToLongTimeString()} - cmd: {request.RawUrl}</body></html>";
        res = request.RawUrl;

        _log.Add($"{DateTime.Now.ToLongTimeString()} :{res.Trim('/')}");

        string responseString;

        if (res.Equals("/exit"))
            responseString = getHtmlB($"IT IS THE OVER.... AAAHHHHHHH");
        else
        {
            responseString = renderAllLog(_log);
        }

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();

        Console.WriteLine($"Получен {request.RawUrl}");
    }
}

string renderAllLog(IEnumerable<string> log)
{
    StringBuilder str = new StringBuilder();// FFFE0B    old b8daff

    string alert_primary = ".alert-primary { color: #FAC189; background-color: #3C6382;}";

    string alert = ".alert " +
        "{font-family: Roboto Condensed, sans-serif;" +
        "position: relative; " +
        "padding: 0.75mm 1.25mm; " +
        "margin-bottom: 4mm; " +
        "border: 2px solid transparent;" +
        "border-color: #003a51;" +
        "-webkit-border-radius: 15px;}";

    string html = "html { background-color: #3C6382;}";

    string styles = $"<style>{html}{alert}{alert_primary}</style>";

    str.Append(styles);

    foreach (var item in log)
    {
        str.Append($"<div class=\"alert alert-primary\">{item}</div>");
    }

    return str.ToString();
}

string getHtmlB(string msg)
{
    StringBuilder str = new StringBuilder();// FFFE0B    old b8daff

    string alert_primary = ".alert-primary { color: #FAC189; background-color: #3C6382;}";

    string alert = ".alert " +
        "{font-family: Roboto Condensed, sans-serif;" +
        "position: relative; " +
        "padding: 0.75mm 1.25mm; " +
        "margin-bottom: 4mm; " +
        "border: 2px solid transparent;" +
        "border-color: #003a51;" +
        "-webkit-border-radius: 15px;}";

    string html = "html { background-color: #3C6382;}";

    string styles = $"<style>{html}{alert}{alert_primary}</style>";

    str.Append(styles);

    str.Append($"<div class=\"alert alert-primary\">{msg}</div>");

    return str.ToString();
}