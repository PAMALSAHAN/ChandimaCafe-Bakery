xamarin preference 
	meka use karanne token wage ewwa tiyaganna ewwa database damahama memory eka wadiyen gihin slow wenawa
	eka hinda preference tiyaganne 4n eka thulamai.
		dan store karana vidiha balamu eke.mekedi manpage xaml eke tina eka save karanna one 
		aniwaryen mokada naththam eka xml.cs ekata enne naha.
	save karapu preference eka ganna button ekak use karanawa.
		retrive button ekak dala eka allaganna label ekak danawa.eke text kiyala liyanne naha.
	ehema livvoth eka screen eke wadinawa.eka hinda hodama de thmai karanna text noda inna eka.
	ita passe preference eken hambena eka label eke txt ekata set karana eka thmai karnne.
-----------------------------------------------------
conveyor install
	meka use karanne api eka test karanna mobile eke tiyalama
---------------------------------------------------------
use karana kota error ekak enawa android eke eka hinda eka resoleve karanna 
	android project eke properties wala AssemblyInfo.cs mala anthima line ekata
		[assembly: Application(UsesCleartextTraffic = true)] meka use karanna.
---------------------------------------------------------------
model class eka hadannna one accounts walata
	mekedi api eke use karana json eka ne model classe ekata enna one. eka hinda ekata 
	use karapu data tiken class ekak hadanna puluwan.
		login register json file add karanakota login eke token file ekek out put karanawane ekata class 
	ekak hadanna one token kiyala.
		delete http request walata model liyanne naha mokada ekata class one wenne nathi hinda.
-----------------------------------------------------------------
ita passe karanna tinne service file ekak add karana eka.
	mekedi nuget package ekak install karanna one serialized and deserialized karanna one hinda 
		registeruser function ekak gahanawa.paramethers thunak aran register eken object ekak hadagannawa
	ita passe kraanne hada gaththa object ka json ekata daganna eka.ita passe hadagathhta jason eka ita passe eka 
	http server ekata yawanna one widihata hadaganna one.ita passe eka postasync eken yawanna one server ekata.
		success nam return karanawa true or false kiyala.
-----------------------------------------------------------------------------
	login ekedi access token ganne menna mehemai.
			var jsonResult =await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userId", result.user_Id);
            Preferences.Set("userName", result.user_name);
--------------------------------------------------------------------------------
	api url eka wenama cs class ekaka property ekak widihata use karana eka thama karanne.ehema karama 
	ulr eka edit karanna prashnayak awoth hamathanama edit karanna wenne naha.
	    hamawelema function liyana kota postman eke uda idan patan ganna tinne.authorize eka hoyana eka.ita passe 
		httprequest eka. eka getasync deleteasync wage wenna puluwan.

		 public async  static Task<bool> ClearShoppingCart(int userId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.DeleteAsync(AppSetting.ApiURL + "api/ShoppingCartItems/" + userId);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
--------------------------------------------------
order class eka hadana kota
	eka hadanakota body ekata wenama class ekai response ekata wenama class ekai hadanna one.
------------------------------------------------------------------
post request hama ekakma yanne hariyata ekama widihak vidihata. parameter ekak wenna one class eke object ekak 
ethakota lesi 
			
			post request
				public static async Task<bool> AddItemsInCart(AddToCart addToCart)
        {
            var httpClient = new HttpClient();
            //convert object to json 
            var json = JsonConvert.SerializeObject(addToCart);
            //http server client communication ekata adala wena widihata content eka hada ganna eka karanne.
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            //ita passe karanna tinne end point ekata yawanna
            //methanadi use karana endpoint eka wenna one newtonsoft ekka wada karana ka thama.
            var response = await httpClient.PostAsync(AppSetting.ApiURL + "api/ShoppingCartItems", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

			getrequest
				 public async static Task<CartSubTotal> GetSubTotal(int userId)
        {
            var httpClient =new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSetting.ApiURL + "api/ShoppingCartItems/SubTotal/" + userId);
            return JsonConvert.DeserializeObject<CartSubTotal>(response);

        }

