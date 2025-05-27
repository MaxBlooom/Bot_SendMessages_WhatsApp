using EasyAutomationFramework;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppProject
{
    // Classe responsável por enviar mensagens no WhatsApp Web
    public class WhatsAppSendMessage : Web
    {
        // Envia uma mensagem de texto para um contato específico
        public void SendMessage(string message, string to)
        {
            // Inicia o navegador com o perfil do usuário (mantém login no WhatsApp)
            StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\Max alves\\AppData\\Local\\Google\\Chrome\\User Data");

            // Acessa o WhatsApp Web
            Navigate("https://web.whatsapp.com/");
            WaitForLoad();
            Thread.Sleep(TimeSpan.FromSeconds(4)); // Aguarda a interface carregar completamente

            // Pesquisa o contato e abre a conversa
            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 5);
            elemenSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            // Localiza o campo de mensagem e envia o texto
            var elementMessage = AssignValue(TypeElement.Xpath, "/html/body/div[1]/div/div/div[4]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", message);
            elementMessage.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            CloseBrowser(); // Fecha o navegador após o envio
        }

        // Envia uma mensagem com imagem anexada
        public void SendMessageWithImage(string messsage, string pathImage, string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\Max alves\\AppData\\Local\\Google\\Chrome\\User Data");
            Navigate("https://web.whatsapp.com/");
            WaitForLoad();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 5);
            elemenSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            // Clica no botão de anexar arquivo (clipe)
            Click(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/div/span");

            // Anexa a imagem a partir do caminho fornecido
            AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div/div/ul/li[1]/button/input", pathImage);

            // Envia a legenda da imagem (opcional)
            var elementInput = AssignValue(TypeElement.Xpath, "//*[@id=\"app\"]/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/div/div[1]/div[3]/div/div/div[2]/div[1]/div[1]/p", messsage);
            elementInput.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            CloseBrowser();
        }

        // Envia uma mensagem com emojis inseridos por texto
        public void SendMessageWithEmoji(string message, List<string> emojis, string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\Max alves\\AppData\\Local\\Google\\Chrome\\User Data");
            Navigate("https://web.whatsapp.com/");
            WaitForLoad();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 5);
            elemenSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            // Insere emojis como texto (ex: ":sorriso:")
            foreach (var emoji in emojis)
            {
                AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", ":");
                var element = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", emoji);
                element.element.SendKeys(OpenQA.Selenium.Keys.Tab);
            }

            // Envia a mensagem com os emojis
            var elementInput = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", message);
            elementInput.element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }
    }
}
