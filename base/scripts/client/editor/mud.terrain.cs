//---------------------------------------------------------
// mud terrain file
//---------------------------------------------------------

// the terrain types for this world
function Terrain::Mud::setTypes()
{
   LS::flushTextures();
   
   LS::addTerrainType(S, " 1 Mud");
   LS::addTerrainType(D, " 2 Dirt");
   LS::addTerrainType(T, " 3 Rock");
   LS::addTerrainType(L, " 4 Lite grass");
   LS::addTerrainType(G, " 5 Mud and rock");
}

// default rules for this world type
function Terrain::Mud::setRules()
{
   Terrain::Mud::setTypes();
   LS::flushRules();

   LS::addRule(S, 50.0, 550.0, 150.0, 0.50, 0.50, 0, 0.00, 0.2,  1.5, 0.50, 0.50, 0);
   LS::addRule(D, 00.0, 550.0, 250.0, 0.50, 0.50, 0, 0.00, 1.0,  0.2, 0.50, 0.50, 0);
   LS::addRule(T, 00.0, 550.0, 25.0,  0.50, 0.50, 0, 0.00, 1.0,  0.1, 0.50, 0.50, 0);
   LS::addRule(G, 00.0, 550.0, 25.0,  0.50, 0.50, 0, 0.00, 1.0,  0.1, 0.50, 0.50, 0);
   LS::addRule(L, 00.0, 550.0, 25.0,  0.50, 0.50, 0, 0.00, 1.0,  0.1, 0.50, 0.50, 0);
}

// create the grid file and dml for this world
function Terrain::Mud::createGridFile()
{
   Terrain::Mud::setTypes();

   LS::addTerrainTexture("mdddd1.png", DDDD, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdddd2.png", DDDD, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdddd3.png", DDDD, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdddd4.png", DDDD, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdddd5.png", DDDD, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtttt1.png", TTTT, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtttt2.png", TTTT, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtttt3.png", TTTT, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtttt4.png", TTTT, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtttt5.png", TTTT, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mssss1.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss2.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss3.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss4.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss5.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss6.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss7.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss8.png", SSSS, 0xFF, 11, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mssss9.png", SSSS, 0xFF, 12, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mllll1.png", LLLL, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mllll2.png", LLLL, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mllll3.png", LLLL, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mllll4.png", LLLL, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mllll5.png", LLLL, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mddss1.png", DDSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mddtt1.png", DDTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdsss1.png", DSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mdttt1.png", DTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("msddd1.png", SDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msstt1.png", SSTT, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("msttt1.png", STTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtddd1.png", TDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtddd.png", TDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdsss.png", DSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mddss.png", DDSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mddtt.png", DDTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdttt.png", DTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("msddd.png", SDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msstt.png", SSTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("msttt.png", STTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtsss.png", TSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mtsss1.png", TSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mtlll1.png", TLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdtll1.png", DTLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtldd1.png", TLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlss1.png", DLSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mdsll1.png", DSLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msldd1.png", SLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msltt1.png", SLTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstll1.png", STLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtlss1.png", TLSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtlll.png", TLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mttll.png", TTLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlsss.png", LSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mslll.png", SLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mssll.png", SSLL, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mddll.png", DDLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlll.png", DLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlll1.png", DLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlddd.png", LDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msltt.png", SLTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstll.png", STLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtlss.png", TLSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlttt.png", LTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mddll1.png", DDLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlddd1.png", LDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdltt.png", DLTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdtll.png", DTLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mtldd.png", TLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlss.png", DLSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mdsll.png", DSLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdstt.png", DSTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdstt1.png", DSTT, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdtss.png", DTSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdtss1.png", DTSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("msldd.png", SLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstdd.png", STDD, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstdd1.png", STDD, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlttt1.png", LTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mdltt1.png", DLTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mttll1.png", TTLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlsss1.png", LSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mslll1.png", SLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mssll1.png", SSLL, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgggg1.png", GGGG, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgggg2.png", GGGG, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgggg3.png", GGGG, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgggg4.png", GGGG, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("msggg.png", SGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgtss.png", GTSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstgg.png", STGG, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mdgtt.png", DGTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mdtgg.png", DTGG, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mgtdd.png", GTDD, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdgss.png", DGSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mdsgg.png", DSGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgsdd.png", GSDD, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggtt.png", GGTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mgttt.png", GTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtggg.png", TGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggss.png", GGSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgsss.png", GSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgstt.png", GSTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mddgg.png", DDGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdggg.png", DGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgddd.png", GDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("msggg1.png", SGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgtss1.png", GTSS, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mstgg1.png", STGG, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mdgtt1.png", DGTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mdtgg1.png", DTGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgtdd1.png", GTDD, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdgss1.png", DGSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mdsgg1.png", DSGG, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgsdd1.png", GSDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggtt1.png", GGTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mgttt1.png", GTTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mtggg1.png", TGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggss1.png", GGSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgsss1.png", GSSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgstt1.png", GSTT, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("mddgg1.png", DDGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdggg1.png", DGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgddd1.png", GDDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdgll.png", DGLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdgll1.png", DGLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlgg.png", DLGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mdlgg1.png", DLGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggll.png", GGLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mggll1.png", GGLL, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgldd.png", GLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgldd1.png", GLDD, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mglll.png", GLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mglll1.png", GLLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mglss.png", GLSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mglss1.png", GLSS, 0xFF, 50, Mud, 0.5, 1.0);
   LS::addTerrainTexture("mgsll.png", GSLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mgsll1.png", GSLL, 0xFF, 50, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlggg.png", LGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mlggg1.png", LGGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mslgg.png", SLGG, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("mslgg1.png", SLGG, 0xFF, 50, PackedEarth, 0.5, 1.0);

   // create the dat and dml for this world
   LS::createGridFile("temp/mud.grid.dat", "temp/mud.dml");
}
