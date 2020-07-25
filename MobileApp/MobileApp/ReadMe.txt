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
---------------------------------------------------------------------------------
srollveiw kiyanne page eka scroll wenna one nam use  karana ekak.eka nathiwa use karanna baha.
-------------------------------------------------------------------------------------------------
	login page eka create karala sign up eka page eken lagin page ekata navigate wenna ona ne eka hinda 
	karanna tinne meka navigation page ekak widihata hadaganna eka.ekta app.xml eka main page eka edit karanna one.
		 <Image.GestureRecognizers> meken karanne  image karana eka tap karann one tap gannna one xaml ekak.
-----------------------------------------------------------------------
	eka parak login wenna hadanna one nam karanna tinne token eka allagena eka 
		use karala page eka navigate wenna hadana eka.
			 var token=Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(token))
            {
                MainPage = new NavigationPage(new SignUp());
            }
            else
            {
                MainPage = new NavigationPage(new Home());
            }
	eka parak log unama e token eka mobile eka tiyaganna hinda log una kena hadunaganna puluwan ethakota 
	hama welema log wewi inna one naha.
-----------------------------------------------------------------------------------------------------------------
home page eka 
	meke grid ekak hadala tinwa eka hadala tinne 150 heigth eka parts 4 kata bedala. eka bedala tina widiha balanna whole 
	screen ekama neme bedala tinne. 
		mulinma hadala tinne banner image ka eke aspect eka fill denna one naththam kotasak thma enne.
			row span karala tinne ehema karamhama 4 tama yanawa.column span karama column 3 tama yanawa.
		palleha tinawanam menu eka init karala.ita udin kfc image eka tinawanam udama layer eke tinne pahalama eka.dekama eka 
		layer eke neme tinne.hama welema pahala tina eka thma udama layer eke tinne.
	 Forms.SetFlags("CollectionView_Experimental");
		meka use karanne collection view eka experimental kiyala dena eka.
------------------------------------------------------------------
	collectionview eke note eka balanna.
----------------------------------------------------------------------------
	side bar
		mekedi menu icon eka click karahama side bar eka enna one ita passe eliya click krahama 
		sidebar eka ain wenna one.mekata dala tinne view box ekak hinda karanna tiyenne tapp ekata function ekak liyana 
		eka witharai.
---------------------------------------------------------------------
	popular products ganna tinne.
		ekata mulinma karanne home eke init eke functon ekak liyanawa eken api eke endpoint ekata call karala eke data 
		tika obsevarable collection ekata dagannawa.
			mekedi observerable collection ekakma ganna hethuwa thmai list ekak gaththa kiyala list eka trigger una kiyla 
			ui eka danne naha.eka hinda ganne observarable ekak.
			  observerable list ekata data gathhahama karanna tinne ui ekaka dan connct karana eka.ekata karanna tinne
		ita passe tinne collctionview eke item source ekata 
			ita passe karanne data binding karana eka.eken each cell(not use )
				data dennna puluwan.
			data template ekata danne.mekedi image url eka ganna one source eke idan eka hinda nikan imageURL deela wadak wenne 
			naha.eka hinda karanna tinne apiurl ekath ekka denna one.
				eka hinda popular product eka full image url ekak danawa. 
			me widihata get category eka hadanawa.
---------------------------------------------------------------------------------------------
	user name eka ganna one unama karanne preference(username) eken ganna eka.mokada service ekedi eka store karaganna hinda.
---------------------------------------------------
	get cart number 
		home eke ctor eka eka parai call wenne.eka hinda cart number eka ganna one nam karanna tinne 
		onappearing eka ganna eka.eka home ekata ena hama welekama run wenawa.ethakota updates wena ewwa okkama wage liyanna one 
		eke.
------------------------------------------------------------------------------------------------
ita passe karanna tinne eka eka category ekata adala products tika penna ganna.category item eka tap karana eka karanna tinne
mekedi tap ekata wada use karanne selection changed kiyana eka.mokada category eka tinne collection view ekak yatathe hinda.
	meke ekaparak category item eka click karoth yanawa.aye back wela ekama click karata navigate wenne naha eka hinda 
	karanna tinne selecteditem eka null karana eka. 
-------------------------------------------------------------------------------
	mekedi category eka click karahama eken categoryid ekai category name ekai product list ekata yawanna one.ekata 
	karanne navigation ekedi currentselection eke id ekai name eki parmeter widihata pass karanawa.product list ekedi e 
	deka allaganna one.
----------------------------------------------------------------------------
	product details pennanna tinne
		mekedi wenne kisiyam category ekak click karahama ekanamane product list ekak eke product ekak click karahama 
		product details enna one.
			mekedi productDetail eke hadanawa GetproductById() meke productid eka pass karama hari.
--------------------------------------------------------------------------------
porular products eketh wena wenama detail pennanna one 
	var currentSelection = e.CurrentSelection.FirstOrDefault() as ProductByCategory;
            if (currentSelection == null) return ;
            ((CollectionView)sender).SelectedItem = null;
            Navigation.PushModalAsync(new ProductDetails(currentSelection.id));

			menna meka thamai copy karala watenna one eka  popular porducts ganna kota cast karanna one popular products 
		walin mokada collectionView ekata enne popular product class eken eka hinda e class eka use karanna one.
---------------------------------------------------------------------------------------------------
shopping cart eka tap kalahama card list ekata enna one.
	
		