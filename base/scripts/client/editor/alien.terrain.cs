//---------------------------------------------------------
// alien terrain file
//---------------------------------------------------------

// the terrain types for this world
function Terrain::Alien::setTypes()
{
   LS::flushTextures();
   
   LS::addTerrainType(C, " 1 mottled sands");
   LS::addTerrainType(R, " 2 light sand");
   LS::addTerrainType(D, " 3 cracked earth");
   LS::addTerrainType(G, " 4 moss");
   LS::addTerrainType(P, " 5 path in moss");
   LS::addTerrainType(S, " 6 path in sand");
}

// default rules for this world type
function Terrain::Alien::setRules()
{
   Terrain::Alien::setTypes();
   LS::flushRules();
   
   LS::addRule(C, 50.0, 550.0, 150.0, 0.50, 0.30, 0, 0.00, 8.0, 1.5, 0.50, 0.70, 0);
   LS::addRule(R, 00.0, 550.0, 250.0, 0.50, 0.50, 0, 0.00, 1.0, 0.2, 0.50, 0.50, 0);
   LS::addRule(D, 00.0, 550.0, 25.0,  0.70, 0.50, 0, 0.00, 1.0, 0.1, 0.50, 0.30, 0); 
   LS::addRule(G, 00.0, 550.0, 25.0,  0.10, 0.50, 0, 0.00, 1.0, 0.1, 0.50, 0.90, 0);
}

// create the grid file and dml for this world
function Terrain::Alien::createGridFile()
{
   Terrain::Alien::setTypes();
   
   LS::addTerrainTexture("ACCCC1.png", CCCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("ACCCC2.png", CCCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("ACCCC3.png", CCCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("ACCCC4.png", CCCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("ACCCC5.png", CCCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("accdd.png", CCDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("accgg.png", CCGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("accrr.png", CCRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("acddd.png", CDDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("acdgg.png", CDGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("acdrr.png", CDRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("acgdd.png", CGDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("acggg.png", CGGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("acgrr.png", CGRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("acrdd.png", CRDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("acrgg.png", CRGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("acrrr.png", CRRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("adccc.png", DCCC, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("adddd.png", DDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("adddd1.png", DDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("adddd2.png", DDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("adddd3.png", DDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("adddd4.png", DDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("addgg.png", DDGG, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("addrr.png", DDRR, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("adgcc.png", DGCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("adggg.png", DGGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("adgrr.png", DGRR, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("adrcc.png", DRCC, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("adrgg.png", DRGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("adrrr.png", DRRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("agccc.png", GCCC, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("agddd.png", GDDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg.png", GGGG, 0xFF, 16, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg1.png", GGGG, 0xFF, 16, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg2.png", GGGG, 0xFF, 17, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg3.png", GGGG, 0xFF, 17, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg4.png", GGGG, 0xFF, 17, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agggg5.png", GGGG, 0xFF, 17, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("agrrr.png", GRRR, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arccc.png", RCCC, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arddd.png", RDDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("argcc.png", RGCC, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("argdd.png", RGDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("arggg.png", RGGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("arrgg.png", RRGG, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("arrrr.png", RRRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arrrr1.png", RRRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arrrr2.png", RRRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arrrr3.png", RRRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("arrrr4.png", RRRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("APath2a.png", GGPP, 0xFF, 12, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2b.png", GGPP, 0xFF, 12, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2c.png", GGPP, 0xFF, 12, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2D.png", GGPP, 0xFF, 12, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2E.png", GGPP, 0xFF, 12, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2F.png", GGPP, 0xFF, 13, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2G.png", GGPP, 0xFF, 13, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath2H.png", GGPP, 0xFF, 14, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath1A.png", GGGP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath1B.png", GGGP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath1C.png", GGGP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath3A.png", GGGP, 0, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath3B.png", GGGP, 0, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath3C.png", GGGP, 0, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath4A.png", PPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath4B.png", PPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath4C.png", PPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath4D.png", PPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath5A.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath5B.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APath5C.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APathCURVE1A.png", GPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APathCURVE1B.png", GPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APathCURVE1C.png", GPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("APathCURVE1D.png", GPGP, 0xFF, 25, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2a.png", RRSS, 0xFF, 16, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2b.png", RRSS, 0xFF, 16, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2c.png", RRSS, 0xFF, 16, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2D.png", RRSS, 0xFF, 16, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2E.png", RRSS, 0xFF, 18, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath2F.png", RRSS, 0xFF, 18, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath1A.png", RRRS, 0xFF, 50, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath1B.png", RRRS, 0xFF, 50, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath3A.png", RRRS, 0, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath3B.png", RRRS, 0, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath3C.png", RRRS, 0, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath4A.png", SSRS, 0xFF, 33, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath4B.png", SSRS, 0xFF, 33, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath4C.png", SSRS, 0xFF, 34, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath5A.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath5B.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath5C.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath5D.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPath5E.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPathCURVE1A.png", RSRS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPathCURVE1B.png", RSRS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPathCURVE1C.png", RSRS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPathCURVE1D.png", RSRS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("AsPathCURVE1e.png", RSRS, 0xFF, 20, Sand, 0.5, 1.0);

   // create the dat and dml for this world
   LS::createGridFile("temp/alien.grid.dat", "temp/alien.dml");
}