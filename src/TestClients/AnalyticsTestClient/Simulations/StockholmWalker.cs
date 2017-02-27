﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace AnalyticsTestClient.Simulations
{
    public static class StockholmWalker
    {
        private static Random s_rnd = new Random(0);

        // Walker that walks around Old Town of Stockholm in about 25 minutes
        public static Walker OldTown001 => new Walker("OldTown001", s_rnd.Next(), 0.25,
            new GeoCheckpoint(59.32672562179845, 18.068578779697432),
            new GeoCheckpoint(59.32649574546305, 18.068686068058028),
            new GeoCheckpoint(59.326145454723815, 18.068750441074386),
            new GeoCheckpoint(59.32591557446398, 18.068750441074386),
            new GeoCheckpoint(59.32563095865454, 18.068814814090743),
            new GeoCheckpoint(59.32536823425329, 18.069007933139815),
            new GeoCheckpoint(59.32519308352412, 18.069201052188888),
            new GeoCheckpoint(59.32480993815704, 18.069565832614913),
            new GeoCheckpoint(59.32459099600794, 18.069758951663985),
            new GeoCheckpoint(59.324437735664354, 18.070016443729415),
            new GeoCheckpoint(59.324240685635644, 18.070252478122725),
            new GeoCheckpoint(59.32406552909546, 18.07061725854875),
            new GeoCheckpoint(59.323846582150836, 18.070939123630538),
            new GeoCheckpoint(59.32370426588045, 18.0713468194008),
            new GeoCheckpoint(59.323485316608554, 18.07164722681047),
            new GeoCheckpoint(59.323332051279, 18.071947634220138),
            new GeoCheckpoint(59.32309120436475, 18.07211929559709),
            new GeoCheckpoint(59.32300362324552, 18.072312414646163),
            new GeoCheckpoint(59.32289414652911, 18.072569906711593),
            new GeoCheckpoint(59.3228065649021, 18.07289177179338),
            new GeoCheckpoint(59.3228065649021, 18.073235094547286),
            new GeoCheckpoint(59.32344152658493, 18.07362133264543),
            new GeoCheckpoint(59.32371521330703, 18.07366424798967),
            new GeoCheckpoint(59.323802792592645, 18.073685705661788),
            new GeoCheckpoint(59.32399984516017, 18.073750078678145),
            new GeoCheckpoint(59.32417500203886, 18.073814451694503),
            new GeoCheckpoint(59.32431731633812, 18.07390028238298),
            new GeoCheckpoint(59.32456910171544, 18.0739217400551),
            new GeoCheckpoint(59.32489751462176, 18.0739217400551),
            new GeoCheckpoint(59.32516024266191, 18.073986113071456),
            new GeoCheckpoint(59.32544486241346, 18.073964655399337),
            new GeoCheckpoint(59.325751373326355, 18.073814451694503),
            new GeoCheckpoint(59.3259484145963, 18.073707163333907),
            new GeoCheckpoint(59.32604693480286, 18.073578417301192),
            new GeoCheckpoint(59.326178294634, 18.073492586612716),
            new GeoCheckpoint(59.326178294634, 18.072698652744307),
            new GeoCheckpoint(59.326079774808235, 18.071947634220138),
            new GeoCheckpoint(59.32599220139003, 18.071539938449874),
            new GeoCheckpoint(59.32597030800022, 18.070982038974776),
            new GeoCheckpoint(59.32628776077209, 18.07087475061418),
            new GeoCheckpoint(59.3265833175837, 18.0708962082863),
            new GeoCheckpoint(59.32670372888113, 18.070681631565108),
            new GeoCheckpoint(59.3265942640829, 18.070488512516036),
            new GeoCheckpoint(59.326254920967685, 18.069994986057296),
            new GeoCheckpoint(59.32597030800022, 18.06990915536882),
            new GeoCheckpoint(59.32580610712705, 18.069480001926436),
            new GeoCheckpoint(59.325784213617354, 18.068965017795577),
            new GeoCheckpoint(59.325784213617354, 18.068707525730147),
            new GeoCheckpoint(59.32577326685721, 18.06789213418962),
            new GeoCheckpoint(59.32577326685721, 18.067527353763595),
            new GeoCheckpoint(59.32577326685721, 18.067334234714522),
            new GeoCheckpoint(59.32577326685721, 18.06714111566545),
            new GeoCheckpoint(59.325817053876605, 18.066754877567305),
            new GeoCheckpoint(59.32597030800022, 18.0664115548134),
            new GeoCheckpoint(59.3261673480008, 18.066089689731612),
            new GeoCheckpoint(59.32636438685895, 18.0658536553383),
            new GeoCheckpoint(59.326539531551575, 18.06568199396135)
            );

        public static Walker OldTown002 => new Walker("OldTown002", s_rnd.Next(), 0.25,
            new GeoCheckpoint(59.326576476019895, 18.070322215557113),
            new GeoCheckpoint(59.32643964445466, 18.07040804624559),
            new GeoCheckpoint(59.32650532367474, 18.070719182491317),
            new GeoCheckpoint(59.32639585823743, 18.07167404890062),
            new GeoCheckpoint(59.326116719776365, 18.072028100490584),
            new GeoCheckpoint(59.3261002997955, 18.07237142324449),
            new GeoCheckpoint(59.32583210565149, 18.071566760540023),
            new GeoCheckpoint(59.325755478364464, 18.071191251277938),
            new GeoCheckpoint(59.325542015725276, 18.07116979360582),
            new GeoCheckpoint(59.325279290636445, 18.071191251277938),
            new GeoCheckpoint(59.3250056165092, 18.07115906476976),
            new GeoCheckpoint(59.32494540790546, 18.070772826671615),
            new GeoCheckpoint(59.324934460875134, 18.07040804624559),
            new GeoCheckpoint(59.32514792733039, 18.070279300212874),
            new GeoCheckpoint(59.325366865891716, 18.07011836767198),
            new GeoCheckpoint(59.32539423311272, 18.070043265819564),
            new GeoCheckpoint(59.32539423311272, 18.070043265819564),
            new GeoCheckpoint(59.325361392444876, 18.069764316082015),
            new GeoCheckpoint(59.32525739678736, 18.069496095180526),
            new GeoCheckpoint(59.32500014300417, 18.069710671901717),
            new GeoCheckpoint(59.324803096236224, 18.06986087560655),
            new GeoCheckpoint(59.324633416159486, 18.06965702772142),
            new GeoCheckpoint(59.32509319246969, 18.069206416606917),
            new GeoCheckpoint(59.325323078292286, 18.069002568721785),
            new GeoCheckpoint(59.32553654230664, 18.068820178508773),
            new GeoCheckpoint(59.32573905820905, 18.068798720836654),
            new GeoCheckpoint(59.325985359707225, 18.068745076656356),
            new GeoCheckpoint(59.3261659796714, 18.068745076656356),
            new GeoCheckpoint(59.3264177513531, 18.06868070364),
            new GeoCheckpoint(59.32665857469459, 18.06865924596788),
            new GeoCheckpoint(59.32693770870499, 18.069560468196883),
            new GeoCheckpoint(59.327107377277216, 18.069989621639266),
            new GeoCheckpoint(59.32698696741, 18.07042950391771),
            new GeoCheckpoint(59.32676803928565, 18.07088011503221),
            new GeoCheckpoint(59.32634112538656, 18.07116979360582),
            new GeoCheckpoint(59.32607840647532, 18.07135218381883),
            new GeoCheckpoint(59.32599630639905, 18.071491658687606),
            new GeoCheckpoint(59.326127666425876, 18.072210490703597),
            new GeoCheckpoint(59.3262535526418, 18.073208272457137),
            new GeoCheckpoint(59.32640680479703, 18.073530137538924),
            new GeoCheckpoint(59.32653816323717, 18.07416313886644),
            new GeoCheckpoint(59.326784458943905, 18.074506461620345),
            new GeoCheckpoint(59.32695412828126, 18.074678122997298),
            new GeoCheckpoint(59.32715116257771, 18.074442088603988),
            new GeoCheckpoint(59.32722231357066, 18.074334800243392)
            );


        public static Walker OldTown003 => new Walker("OldTown003", s_rnd.Next(), 0.25,
            new GeoCheckpoint(59.32588136595906, 18.068908691406264),
            new GeoCheckpoint(59.32595799296224, 18.069938659667983),
            new GeoCheckpoint(59.326242606032835, 18.070711135864272),
            new GeoCheckpoint(59.32657100276786, 18.070625305175795),
            new GeoCheckpoint(59.326724253491534, 18.07026052474977),
            new GeoCheckpoint(59.32656005626116, 18.07099008560182),
            new GeoCheckpoint(59.32594704625807, 18.071311950683608),
            new GeoCheckpoint(59.326100299795485, 18.071955680847182),
            new GeoCheckpoint(59.32615503303421, 18.072706699371352)
            );

        public static Walker OldTown004 => new Walker("OldTown004", s_rnd.Next(), 0.25,
           new GeoCheckpoint(59.32516294722102, 18.070879988874644),
           new GeoCheckpoint(59.32522862890848, 18.07119112512037),
           new GeoCheckpoint(59.32548040753448, 18.07120185395643),
           new GeoCheckpoint(59.32561724296192, 18.071158938612193),
           new GeoCheckpoint(59.325748604453935, 18.071116023267955),
           new GeoCheckpoint(59.32590733224602, 18.071030192579478),
           new GeoCheckpoint(59.326011325914735, 18.070912175382823),
           new GeoCheckpoint(59.32629593853868, 18.070804887022227),
           new GeoCheckpoint(59.32659149527917, 18.070590310301036),
           new GeoCheckpoint(59.32658602202956, 18.070418648924083),
           new GeoCheckpoint(59.32653676274339, 18.07071905633375),
           new GeoCheckpoint(59.32591827896297, 18.06994658013746),
           new GeoCheckpoint(59.325792391505104, 18.069292121137828),
           new GeoCheckpoint(59.325458513814965, 18.069302849973887),
           new GeoCheckpoint(59.325152000260765, 18.069560342039317),
           new GeoCheckpoint(59.32516294722102, 18.070182614530772),
           new GeoCheckpoint(59.32504800396251, 18.07051520844862),
           new GeoCheckpoint(59.325053477459825, 18.070804887022227)
           );

        public static Walker OldTown005 => new Walker("OldTown005", s_rnd.Next(), 0.25,
           new GeoCheckpoint(59.3263493353198, 18.068678021430983),
           new GeoCheckpoint(59.32613040308769, 18.068667292594924),
           new GeoCheckpoint(59.325873155912745, 18.06874239444734),
           new GeoCheckpoint(59.325632327005465, 18.0688067674637),
           new GeoCheckpoint(59.32542433703033, 18.06898915767671),
           new GeoCheckpoint(59.32508498223295, 18.0692573785782),
           new GeoCheckpoint(59.3248879359569, 18.069386124610915),
           new GeoCheckpoint(59.32476204468242, 18.069622159004226),
           new GeoCheckpoint(59.32478393885061, 18.06998693943025),
           new GeoCheckpoint(59.324898883002206, 18.070383906364455),
           new GeoCheckpoint(59.32499740625131, 18.070609211921706),
           new GeoCheckpoint(59.32511234968094, 18.0707701444626),
           new GeoCheckpoint(59.32514519058944, 18.070383906364455),
           new GeoCheckpoint(59.32547907135773, 18.069965481758132),
           new GeoCheckpoint(59.32564874721244, 18.06980454921724),
           new GeoCheckpoint(59.325840315707694, 18.069675803184523),
           new GeoCheckpoint(59.32595525628652, 18.07022297382356),
           new GeoCheckpoint(59.32604282979994, 18.070587754249587),
           new GeoCheckpoint(59.326245342685404, 18.07049119472505),
           new GeoCheckpoint(59.32650258704307, 18.070319533348098),
           new GeoCheckpoint(59.32656826614149, 18.070716500282302),
           new GeoCheckpoint(59.32656826614149, 18.070716500282302),
           new GeoCheckpoint(59.325977149686025, 18.071338772773757),
           new GeoCheckpoint(59.32528202736657, 18.071177840232863),
           new GeoCheckpoint(59.32518897841806, 18.070695042610183)
           );

        public static Walker OldTown006 => new Walker("OldTown006", s_rnd.Next(), 0.25,
           new GeoCheckpoint(59.326456064271596, 18.069453179836287),
           new GeoCheckpoint(59.32625902594499, 18.06967848539354),
           new GeoCheckpoint(59.32641775135312, 18.070268571376815),
           new GeoCheckpoint(59.32666952116958, 18.07041877508165),
           new GeoCheckpoint(59.32659836901922, 18.071019589900985),
           new GeoCheckpoint(59.3260400931311, 18.07139509916307),
           new GeoCheckpoint(59.32601272643019, 18.07164186239244),
           new GeoCheckpoint(59.326051039805286, 18.07212466001512),
           new GeoCheckpoint(59.32593062619525, 18.073079526424422),
           new GeoCheckpoint(59.32527929063646, 18.07335847616197),
           new GeoCheckpoint(59.32509866595974, 18.072736203670516),
           new GeoCheckpoint(59.325126033396714, 18.07188862562181),
           new GeoCheckpoint(59.325115086424574, 18.071223437786117),
           new GeoCheckpoint(59.32504940451767, 18.070783555507674),
           new GeoCheckpoint(59.32487425214535, 18.070279300212874),
           new GeoCheckpoint(59.324781202080395, 18.069839417934432),
           new GeoCheckpoint(59.32473741372639, 18.069571197032943),
           new GeoCheckpoint(59.325175294727714, 18.069238603115096),
           new GeoCheckpoint(59.3253394986487, 18.068981111049666),
           new GeoCheckpoint(59.325717164656176, 18.06886309385301),
           new GeoCheckpoint(59.3258923126844, 18.06992524862291)
           );

        public static Walker OldTown007 => new Walker("OldTown007", s_rnd.Next(), 0.25,
            new GeoCheckpoint(59.3257965287183, 18.069160819053664),
            new GeoCheckpoint(59.32526013351929, 18.069439768791213),
            new GeoCheckpoint(59.32536960261483, 18.069761633873),
            new GeoCheckpoint(59.32544623077192, 18.06999766826631),
            new GeoCheckpoint(59.325238239657864, 18.070212244987502),
            new GeoCheckpoint(59.325117823167936, 18.07049119472505),
            new GeoCheckpoint(59.32515066407113, 18.070855975151076),
            new GeoCheckpoint(59.325216345782344, 18.07126367092134),
            new GeoCheckpoint(59.325435283902905, 18.0712207555771),
            new GeoCheckpoint(59.32573084812839, 18.071134924888625),
            new GeoCheckpoint(59.32589504936518, 18.071113467216506),
            new GeoCheckpoint(59.32605924980862, 18.070898890495315),
            new GeoCheckpoint(59.32637670174967, 18.07055556774141),
            new GeoCheckpoint(59.326453327636, 18.07027661800386),
            new GeoCheckpoint(59.32635480860756, 18.07004058361055),
            new GeoCheckpoint(59.32623439607384, 18.06974017620088),
            new GeoCheckpoint(59.32597167633752, 18.069847464561477),
            new GeoCheckpoint(59.32585126244628, 18.069675803184523)
            );
    }
}


/*
        public static Walker TemplateWalker => new Walker("PUT_GAME_SESSION_ID_HERE", 0, 1,
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),
            new GeoCheckpoint(),    
            );























 */
