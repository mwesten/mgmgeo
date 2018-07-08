﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Notice: Use of the service proxies that accompany this notice is subject to
//            the terms and conditions of the license agreement located at
//            http://go.microsoft.com/fwlink/?LinkID=202740&clcid=0x409
//            If you do not agree to these terms you may not use this content.
namespace Microsoft
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Net;
    using System.IO;


    /// <summary>
    /// Class used for Bing translation
    /// </summary>
    public partial class Translation
    {

        private String _Text;

        /// <summary>
        /// Get / Set translation text
        /// </summary>
        public String Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }
    }

    /// <summary>
    /// Class used for Bing translation
    /// </summary>
    public partial class Language
    {

        private String _Code;

        /// <summary>
        /// Get / Set language code
        /// </summary>
        public String Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }
    }

    /// <summary>
    /// Class used for Bing translation
    /// </summary>
    public partial class DetectedLanguage
    {

        private String _Code;

        /// <summary>
        /// Get / Set detected language code
        /// </summary>
        public String Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }
    }

    /// <summary>
    /// Class that performs bing translation
    /// </summary>
    public partial class TranslatorContainer : System.Data.Services.Client.DataServiceContext
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceRoot">web service URI</param>
        public TranslatorContainer(Uri serviceRoot) :
            base(serviceRoot)
        {
        }

        /// <summary>
        /// Performs translation
        /// </summary>
        /// <param name="Text">the text to translate Sample Values : hello</param>
        /// <param name="To">the language code to translate the text into Sample Values : nl</param>
        /// <param name="From">the language code of the translation text Sample Values : en</param>
        public DataServiceQuery<Translation> Translate(String Text, String To, String From)
        {
            if ((Text == null))
            {
                throw new System.ArgumentNullException("Text", "Text value cannot be null");
            }
            if ((To == null))
            {
                throw new System.ArgumentNullException("To", "To value cannot be null");
            }
            DataServiceQuery<Translation> query;
            query = base.CreateQuery<Translation>("Translate");
            if ((Text != null))
            {
                query = query.AddQueryOption("Text", string.Concat("\'", System.Uri.EscapeDataString(Text), "\'"));
            }
            if ((To != null))
            {
                query = query.AddQueryOption("To", string.Concat("\'", System.Uri.EscapeDataString(To), "\'"));
            }
            if ((From != null))
            {
                query = query.AddQueryOption("From", string.Concat("\'", System.Uri.EscapeDataString(From), "\'"));
            }
            return query;
        }

        /// <summary>
        /// Get available languages for translation
        /// </summary>
        /// <returns>available language</returns>
        public DataServiceQuery<Language> GetLanguagesForTranslation()
        {
            DataServiceQuery<Language> query;
            query = base.CreateQuery<Language>("GetLanguagesForTranslation");
            return query;
        }

        /// <summary>
        /// Detect language from text
        /// </summary>
        /// <param name="Text">the text whose language is to be identified Sample Values : hello</param>
        /// <returns>detected language</returns>
        public DataServiceQuery<DetectedLanguage> Detect(String Text)
        {
            if ((Text == null))
            {
                throw new System.ArgumentNullException("Text", "Text value cannot be null");
            }
            DataServiceQuery<DetectedLanguage> query;
            query = base.CreateQuery<DetectedLanguage>("Detect");
            if ((Text != null))
            {
                query = query.AddQueryOption("Text", string.Concat("\'", System.Uri.EscapeDataString(Text), "\'"));
            }
            return query;
        }
    }

    /// <summary>
    /// Easy to use class to perform Bing translation
    /// </summary>
    public class BingTranslator
    {
        /// <summary>
        /// Translate a text
        /// </summary>
        /// <param name="accountKey">Bing account key</param>
        /// <param name="sourceLng">source language</param>
        /// <param name="targetLng">target language</param>
        /// <param name="inputString">text to translate</param>
        /// <param name="outputString">translated text</param>
        /// <returns>error code:
        /// 0 : translation successful
        /// -1: inputstring is empty
        /// -2: text cannot be translated (invalid source language or not detected source language)
        /// -3: error during translation
        /// </returns>
        public static int TranslateMethod(String accountKey, string sourceLng, string targetLng, string inputString, out string outputString)
        {
            outputString = "";
            // Call GetInputString to manage the input
            //inputString = "This is a lovely slice of text that I'd like to translate";//GetInputString(args);

            // Verify that the user actually provided some input
            if (inputString == "")
            {
                //Console.WriteLine("Usage: RandomTranslator.exe Some Input Text");
                return -1;
            }

            // Improved support for unicode
            //Console.OutputEncoding = Encoding.UTF8;

            // Print the input string
            //Console.WriteLine("Input: " + inputString);

            //Console.WriteLine();

            // Call a InitializeTranslatorContainer to get a TranslatorContainer
            // that is configured to use your account.
            TranslatorContainer tc = InitializeTranslatorContainer(accountKey);

            // DetectSourceLanguage encapsulates the work required for language
            // detection
            DetectedLanguage sourceLanguage = null;
            if ((sourceLng == null) || (sourceLng == ""))
                sourceLanguage = DetectSourceLanguage(tc, inputString);
            else
            {
                sourceLanguage = new DetectedLanguage();
                sourceLanguage.Code = sourceLng;
            }

            // Handle the error condition
            if (sourceLanguage == null)
            {
                //Console.WriteLine("\tThis string cannot be translated");

                return -2;
            }

            // Print the detected language code
            //Console.WriteLine("Detected Source Language: " + sourceLanguage.Code);

            //Console.WriteLine();

            // PickRandomLanguage encapsulates the work required to detect all
            // languages supported by the service and then to pick one at random
            var targetLanguage = PickRandomLanguage(tc);
            targetLanguage.Code = targetLng;

            // Print the selected language code
            //Console.WriteLine("Randomly Selected Target Language: " + targetLanguage.Code);

            //Console.WriteLine();

            // TranslateString encapsulates the work required to translate
            // a string from the source language to the target language
            var translationResult = TranslateString(tc, inputString, sourceLanguage, targetLanguage);

            // Handle the error condition
            if (translationResult == null)
            {
                //Console.WriteLine("Translation Failed.");
                return -3;
            }

            // Print the result of the translation
            //Console.WriteLine("Translated String: " + translationResult.Text);
            outputString = translationResult.Text;
            return 0;
        }

        /// <summary>
        /// Creates an instance of a TranslatorContainer that calls the public 
        /// production MicrosoftTranslator service
        /// </summary>
        /// <returns>The generated TranslatorContainer</returns>
        private static TranslatorContainer InitializeTranslatorContainer(String accountKey)
        {
            // this is the service root uri for the Microsoft Translator service 
            var serviceRootUri = new Uri("https://api.datamarket.azure.com/Bing/MicrosoftTranslator/");

            // this is the Account Key I generated for this app
            //var accountKey = "D0VUOytsM8NnicdPNpRaDY3tH79HOIhFY+CWyLYe3oo";

            // Replace the account key above with your own and then delete 
            // the following line of code. You can get your own account key
            // for from here: https://datamarket.azure.com/account/keys
            //throw new Exception("Invalid Account Key");

            // the TranslatorContainer gives us access to the Microsoft Translator services
            var tc = new TranslatorContainer(serviceRootUri);

            // Give the TranslatorContainer access to your subscription
            tc.Credentials = new NetworkCredential(accountKey, accountKey);
            return tc;
        }

        /// <summary>
        /// Uses the TranslatorContainer to identify the Language in which inputString was written
        /// </summary>
        /// <param name="tc">The TranslatorContainer to use</param>
        /// <param name="inputString">The string to identify</param>
        /// <returns>The Language Code for a language that this string could represent,
        /// or null if one is not found.</returns>
        private static DetectedLanguage DetectSourceLanguage(TranslatorContainer tc, string inputString)
        {
            // calling Detect gives us a DataServiceQuery which we can use to call the service
            var translateQuery = tc.Detect(inputString);

            // since this is a console application, we do not want to do an asynchronous 
            // call to the service. Otherwise, the program thread would likely terminate
            // before the result came back, causing our app to appear broken.
            var detectedLanguages = translateQuery.Execute().ToList();

            // since the result of the query is a list, there might be multiple
            // detected languages. In practice, however, I have only seen one.
            // Some input strings, 'hi' for example, are obviously valid in 
            // English but produce other results, suggesting that the service
            // only returns the first result.
            if (detectedLanguages.Count() > 1)
            {
                Console.WriteLine("Possible source languages:");

                foreach (var language in detectedLanguages)
                {
                    Console.WriteLine("\t" + language.Code);
                }

                Console.WriteLine();
            }

            // only continue if the Microsoft Translator identified the source language
            // if there are multiple, let's go with the first.
            if (detectedLanguages.Count() > 0)
            {
                return detectedLanguages.First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Asks the service represented by the TranslatorContainer for a list
        /// of all supported languages.
        /// </summary>
        /// <returns>All supported Languages.</returns>
        public static Language[] GetSupportedLanguages(String accountKey)
        {
            // Call a InitializeTranslatorContainer to get a TranslatorContainer
            // that is configured to use your account.
            TranslatorContainer tc = InitializeTranslatorContainer(accountKey);

            // Generate the query
            var languagesForTranslationQuery = tc.GetLanguagesForTranslation();

            // Call the query to get the results as an Array
            var availableLanguages = languagesForTranslationQuery.Execute().ToArray();

            // Return list of supported languages
            return availableLanguages;
        }

        /// <summary>
        /// Asks the service represented by the TranslatorContainer for a list
        /// of all supported languages and then picks one at random.
        /// </summary>
        /// <param name="tc">The TranslatorContainer to use.</param>
        /// <returns>A randomly selected Language.</returns>
        private static Language PickRandomLanguage(TranslatorContainer tc)
        {
            // Used to generate a random index
            var random = new Random();

            // Generate the query
            var languagesForTranslationQuery = tc.GetLanguagesForTranslation();

            // Call the query to get the results as an Array
            var availableLanguages = languagesForTranslationQuery.Execute().ToArray();

            // Generate a random index between 0 and the total number of items in the array
            var randomIndex = random.Next(availableLanguages.Count());

            // Select the randomIndex'th value from the array
            var selectedLanguage = availableLanguages[randomIndex];

            return selectedLanguage;
        }

        /// <summary>
        /// Uses the TranslatorContainer to translate inputString from sourceLanguage
        /// to targetLanguage.
        /// </summary>
        /// <param name="tc">The TranslatorContainer to use</param>
        /// <param name="inputString">The string to translate</param>
        /// <param name="sourceLanguage">The Language Code to use in interpreting the input string.</param>
        /// <param name="targetLanguage">The Language Code to translate the input string to.</param>
        /// <returns>The translated string, or null if no translation results were found.</returns>
        private static Translation TranslateString(TranslatorContainer tc, string inputString, DetectedLanguage sourceLanguage, Language targetLanguage)
        {
            // Generate the query
            var translationQuery = tc.Translate(inputString, targetLanguage.Code, sourceLanguage.Code);

            // Call the query and get the results as a List
            var translationResults = translationQuery.Execute().ToList();

            // Verify there was a result
            if (translationResults.Count() <= 0)
            {
                return null;
            }

            // In case there were multiple results, pick the first one
            var translationResult = translationResults.First();

            return translationResult;
        }
    }
}
