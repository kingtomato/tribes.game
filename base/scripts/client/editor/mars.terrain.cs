//---------------------------------------------------------
// mars terrain file
//---------------------------------------------------------

// the terrain types for this world
function Terrain::Mars::setTypes()
{
   LS::flushTextures();
   
   LS::addTerrainType(G, " 1 Rough sand");
   LS::addTerrainType(S, " 2 Smooth sand");
   LS::addTerrainType(C, " 3 Rough sand and rock");
   LS::addTerrainType(R, " 4 Rock");
   LS::addTerrainType(D, " 5 Rough and smooth sand");
   LS::addTerrainType(L, " 6 Lined clay");
}

// default rules for this world type
function Terrain::Mars::setRules()
{
   Terrain::Mars::setTypes();
   LS::flushRules();

   LS::addRule(D, 0.0, 350.0, 150.0, 0.50, 0.50, 0, 0.00, 8.0, 1.5, 0.50, 0.50, 0);
   LS::addRule(C, 0.0, 350.0, 150.0, 0.50, 0.50, 0, 0.00, 8.0, 1.5, 0.50, 0.50, 0);
   LS::addRule(G, 0.0, 305.0, 25.0,  0.50, 0.50, 0, 0.10, 4.0, 0.5, 0.50, 0.50, 0);
   LS::addRule(S, 0.0, 450.0, 100.0, 0.50, 0.50, 0, 0.00, 2.0, 0.3, 0.50, 0.50, 0);
   LS::addRule(R, 0.0, 400.0, 150.0, 0.50, 0.40, 0, 0.00, 8.0, 0.5, 0.50, 0.30, 0);
   LS::addRule(L, 0.0, 185.0, 05.0,  0.10, 0.05, 0, 0.00, 1.0, 0.1, 0.60, 0.40, 0);
}

// create the grid file and dml for this world
function Terrain::Mars::createGridFile()
{
   Terrain::Mars::setTypes();

   LS::addTerrainTexture("xCCCC.png", CCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCCCC1.png", CCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCCCC2.png", CCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCCCC3.png", CCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCCCC4.png", CCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDDDD.png", DDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDDD1.png", DDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDDD2.png", DDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDDD3.png", DDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDDD4.png", DDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSSSS.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSSSS1.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSSSS2.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSSSS3.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSSSS4.png", SSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCCDD.png", CCDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCCSS.png", CCSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCDDD.png", CDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCDSS.png", CDSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCSDD.png", CSDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCSSS.png", CSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDCCC.png", DCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDDSS.png", DDSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDSCC.png", DSCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDSSS.png", DSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSCCC.png", SCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xSDDD.png", SDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL1.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL2.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL3.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL4.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLLLL5.png", LLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGGGG.png", GGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGGG1.png", GGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGGG2.png", GGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGGG3.png", GGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGGG4.png", GGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRRRR.png", RRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xRRRR1.png", RRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xRRRR2.png", RRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xRRRR3.png", RRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xRRRR4.png", RRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCCGG.png", CCGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCCLL.png", CCLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCCRR.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCDGG.png", CDGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCDLL.png", CDLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCDRR.png", CDRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCGDD.png", CGDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCGGG.png", CGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCGLL.png", CGLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCGRR.png", CGRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCGSS.png", CGSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCLGG.png", CLGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCLLL.png", CLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCLRR.png", CLRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCLSS.png", CLSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCLGG.png", CLGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCRDD.png", CRDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCRGG.png", CRGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCRLL.png", CRLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCRRR.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xCRSS.png", CRSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCSGG.png", CSGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xCSLL.png", CSLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xCSRR.png", CSRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xDDGG.png", DDGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDLL.png", DDLL, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDDRR.png", DDRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDGCC.png", DGCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDGGG.png", DGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDGLL.png", DGLL, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDGRR.png", DGRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDGSS.png", DGSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDLCC.png", DLCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDLGG.png", DLGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDLLL.png", DLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDLRR.png", DLRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xDLSS.png", DLSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDRCC.png", DRCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDRGG.png", DRGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDRLL.png", DRLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xDRRR.png", DRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xDRSS.png", DRSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDSGG.png", DSGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDSLL.png", DSLL, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xDSRR.png", DSRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGCCC.png", GCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGDDD.png", GDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGLL.png", GGLL, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGRR.png", GGRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGGSS.png", GGSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGLCC.png", GLCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGLDD.png", GLDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGLLL.png", GLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGLRR.png", GLRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xGLSS.png", GLSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGRCC.png", GRCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGRDD.png", GRDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGRLL.png", GRLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xGRRR.png", GRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xGRSS.png", GRSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGSCC.png", GSCC, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGSDD.png", GSDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGSLL.png", GSLL, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGSRR.png", GSRR, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xGSSS.png", GSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLCCC.png", LCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLDDD.png", LDDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLGGG.png", LGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLLRR.png", LLRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xLLSS.png", LLSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLRCC.png", LRCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLRDD.png", LRDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLRGG.png", LRGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLRRR.png", LRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xLRSS.png", LRSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLSCC.png", LSCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xLSDD.png", LSDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLSGG.png", LSGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xLSRR.png", LSRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("xLSSS.png", LSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRCCC.png", RCCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xRDDD.png", RDDD, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xRGGG.png", RGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRLLL.png", RLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xRRSS.png", RRSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRSCC.png", RSCC, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xRSDD.png", RSDD, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRSGG.png", RSGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xRSLL.png", RSLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xRSSS.png", RSSS, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSGGG.png", SGGG, 0xFF, 20, Sand, 0.5, 1.0);
   LS::addTerrainTexture("xSLLL.png", SLLL, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("xSRRR.png", SRRR, 0xFF, 20, Stone, 0.5, 1.0);

   // create the dat and dml for this world
   LS::createGridFile("temp/mars.grid.dat", "temp/mars.dml");
}
