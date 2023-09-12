
#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Luka 
{

    // luka basic ui version 2
    public class FireUI : ShaderGUI
    {

        // variables
        private const string _version = "1.5";
        LukaSocials socials = new LukaSocials();

        // gui
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            // get the material
            Material targetMat = materialEditor.target as Material;
            // get the shader name
            string shader_name = targetMat.shader.name;
            // create the GUI Style for the header 
            GUIStyle headerStyle = new GUIStyle();
            headerStyle.fontSize = 20;
            headerStyle.richText = true;
            headerStyle.alignment = TextAnchor.MiddleCenter;
            // draw the header
            EditorGUILayout.Space(10);
            string shader_kind =  (shader_name.ToLower().Contains("toon")) ? "Toon" : "Realistic";
            string hex_pastel_red = "#FFB3B3";
            EditorGUILayout.LabelField("<color=" + hex_pastel_red + ">Fire<b>" + shader_kind + "</b></color>", headerStyle, GUILayout.ExpandWidth(true));
            // create the GUI Style for the subheader
            GUIStyle subHeaderStyle = new GUIStyle();
            subHeaderStyle.fontSize = 12;
            subHeaderStyle.richText = true;
            subHeaderStyle.alignment = TextAnchor.MiddleCenter;
            // draw the subheader
            EditorGUILayout.LabelField("<color=" + hex_pastel_red + ">Version<b>" + _version + "</b></color>", subHeaderStyle, GUILayout.ExpandWidth(true));
            // render the default gui
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            base.OnGUI(materialEditor, properties);
            EditorGUILayout.EndVertical();
            // draw socials button
            draw_socials();
        }

        // methods
        private void open_url(string url) {
            Application.OpenURL(url);
        }

        private void popup_dialogue(string title, string message) {
            EditorUtility.DisplayDialog(title, message, "oki");
        }

        private void draw_socials() {
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Check out my Booth!")) {
                socials.demand_fetch();
                open_url(socials.getBooth());
            }
            if (GUILayout.Button("Check out my Gumroad!")) {
                socials.demand_fetch();
                open_url(socials.getGumroad());
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Star my projects on Github!")) {
                socials.demand_fetch();
                open_url(socials.getGithub());
            }
            if (GUILayout.Button("Friend me on Discord!")) {
                socials.demand_fetch();
                popup_dialogue("My Discord Username", socials.getDiscord());
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Visit my Website!")) {
                socials.demand_fetch();
                open_url(socials.getWebsite());
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(10);
        }

        // objects
        class LukaSocials {

            // variables
            private bool state;
            private string github;
            private string booth;
            private string gumroad;
            private string website;
            private string discord;
            
            // constructor
            public LukaSocials() {
                this.state = false;
            }

            // methods
            public void demand_fetch() {
                if (this.state == false) {
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string jsonUrl = "https://www.luka.moe/go/contact.json";
                            HttpResponseMessage response = client.GetAsync(jsonUrl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                string json = response.Content.ReadAsStringAsync().Result;
                                string[] lines = json.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string line in lines)
                                {
                                    string[] key_value = parse_kv(line);
                                    bool is_special_case = (key_value[0] == "parse_kv_debug");
                                    if (!is_special_case)
                                    {
                                        string key = key_value[0];
                                        string value = key_value[1];
                                        switch (key)
                                        {
                                            case "github":
                                                this.github = value;
                                                break;
                                            case "booth":
                                                this.booth = value;
                                                break;
                                            case "gumroad":
                                                this.gumroad = value;
                                                break;
                                            case "website":
                                                this.website = value;
                                                break;
                                            case "discord":
                                                this.discord = value;
                                                break;
                                        }
                                    }
                                }
                                this.state = true;
                            }
                            else
                            {
                                error_defaults();
                            }
                        }
                        catch (Exception e)
                        {
                            error_defaults();
                        }
                    }
                }
            }

            private string[] parse_kv(string input)
            {
                // ensure it is not an end or start line, and if so, return a special case
                string parse_kv_console = "parse_kv_debug";
                if (input == "}" || input == "{")
                {
                    string error_message = "special_case";
                    return new string[] { parse_kv_console, error_message };
                }

                // match quotations with regex
                string pattern = "\"(.*?)\":\\s*\"(.*?)\"";
                Match match = Regex.Match(input, pattern);

                // see if it worked
                if (!match.Success)
                {
                    string error_message = "There was an error getting the contact information! I'm sorry..";
                    return new string[] { parse_kv_console, error_message };
                }

                // extract the key and value from the matched groups
                string key = match.Groups[1].Value.Trim().ToLower();
                string value = match.Groups[2].Value.Trim().ToLower();
                return new string[] { key, value };
            }

            private void error_defaults() {
                // errored..
                this.github = "There was an error getting the contact information! I'm sorry..";
                this.booth = "There was an error getting the contact information! I'm sorry..";
                this.gumroad = "There was an error getting the contact information! I'm sorry..";
                this.website = "There was an error getting the contact information! I'm sorry..";
                this.discord = "There was an error getting the contact information! I'm sorry..";
            }

            // setters
            public void setState(bool state) {
                this.state = state;
            }

            // getters
            public bool getState() {
                return this.state;
            }

            public string getGithub() {
                return this.github;
            }

            public string getBooth() {
                return this.booth;
            }

            public string getGumroad() {
                return this.gumroad;
            }

            public string getWebsite() {
                return this.website;
            }

            public string getDiscord() {
                return this.discord;
            }

        }

    }

}

#endif // UNITY_EDITOR