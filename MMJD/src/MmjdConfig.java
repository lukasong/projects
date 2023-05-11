public class MmjdConfig {

    // external variables
    private String current_username;
    private String level;
    private String gender;
    private String country;
    private String member_status;
    private String monstar;
    private String rating;
    private String referralPoints;
    private String views;
    private String age;
    private String happiness;
    private String health;
    private String highest_puzzle_score;
    private String progress;
    private String rocks;
    private String total_rocks;
    private String monster_type;
    private String b;
    private String primary_colour;
    private String secondary_colour;
    private String custom_colour1;
    private String custom_colour2;
    private String custom_colour3;
    private String do_new_game;
    private String new_username;
    private String initialize_dummy_items;
    private String initialize_dummy_room;
    private String wipe_moshlings;
    private String wipe_items;
    private String wipe_gifts;
    private String wipe_friends;
    private String wipe_comments;
    private String do_experimental;
    private String exp_do_garden;
    private String exp_garden_progress;
    private String exp_garden_nextflower;
    private String exp_difficulty;
    private String createdAfterFoodFactoryLaunch;
    private String exp_force_id;
    private String exp_force_id_value;
    private String do_custom_settings;
    private String profile_template;
    private String beautify_xml;

    // internal variables
    private String[] replace_text_paths;
    private String profile_index_path = "content\\www.moshimonsters.com\\services\\monster\\index.html";
    private String profile_costume_path = "content\\www.moshimonsters.com\\services\\monster\\dressup\\costume\\friend\\%name%";
    private String profile_location_path = "content\\www.moshimonsters.com\\services\\rest\\world\\location\\friends\\%name%";
    private String profile_room_path = "content\\www.moshimonsters.com\\services\\rest\\user\\profile\\inroomownprofile";
    private String profile_location_45 = "content\\www.moshimonsters.com\\services\\rest\\world\\location\\45";
    private String profile_location_51 = "content\\www.moshimonsters.com\\services\\rest\\world\\location\\51";
    private String profile_location_77 = "content\\www.moshimonsters.com\\services\\rest\\world\\location\\77";
    private String profile_saga = "content\\www.moshimonsters.com\\services\\rest\\saga\\progress";
    private String profile_garden = "content\\www.moshimonsters.com\\services\\rest\\garden\\status";

    // constructor
    public MmjdConfig() {
        // to-do
    }

    // populates
    private void populateReplacements() {
        // note to self: may look like directories, but they're actually files
        replace_text_paths = new String[2];
        replace_text_paths[0] = "content\\www.moshimonsters.com\\monsters";
        replace_text_paths[1] = "content\\www.moshimonsters.com\\secretcode";
    }

    // getters

    // setters

    // functions

}
