//---------------------------------------------------------
// ice terrain file
//---------------------------------------------------------

// the terrain types for this world
function Terrain::Ice::setTypes()
{
   LS::flushTextures();
   
   LS::addTerrainType(F, " 1 Snow type 1");
   LS::addTerrainType(D, " 2 Snow type 2");
   LS::addTerrainType(I, " 3 Cracked ice");
   LS::addTerrainType(Y, " 4 Rock");
   LS::addTerrainType(X, " 5 Snow and rock");
   LS::addTerrainType(P, " 6 Walking path");
}

// default rules for this world type
function Terrain::Ice::setRules()
{
   Terrain::Ice::setTypes();
   LS::flushRules();
   
   LS::addRule(I, 15.0, 200.0, 25.0,  0.50, 0.05, 0, 0.10, 0.5, 0.1, 0.50, 0.05, 0);
   LS::addRule(X, 60.0, 350.0, 150.0, 0.50, 0.50, 0, 0.00, 8.0, 0.9, 0.5,  0.50, 0);
   LS::addRule(X, 90.0, 500.0, 90.0,  0.50, 0.5,  0, 0.10, 0.5, 0.1, 0.50, 0.5,  0);
   LS::addRule(Y, 00.0, 350.0, 100.0, 0.50, 0.40, 0, 0.00, 8.0, 1.1, 0.5,  0.40, 0);
   LS::addRule(D, 00.0, 385.0, 200.0, 0.50, 0.50, 0, 0.00, 8.0, 0.7, 0.50, 0.5,  0);
   LS::addRule(F,  0.0, 40.0,  5.0,   0.50, 0.50, 0, 0.0,  4.0, 0.1, 0.50, 0.50, 0);
}

// create the grid file and dml for this world
function Terrain::Ice::createGridFile()
{
   Terrain::Ice::setTypes();

   LS::addTerrainTexture("idddd2.png", DDDD, 0xFF, 34, Snow, 0.5, 1.0);
   LS::addTerrainTexture("idddd1.png", DDDD, 0xFF, 33, Snow, 0.5, 1.0);
   LS::addTerrainTexture("idddd.png", DDDD, 0xFF, 33, Snow, 0.5, 1.0); 
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0); 
   LS::addTerrainTexture("iddff.png", DDFF,  0xFF, 0, Snow, 0.5, 1.0); 
   LS::addTerrainTexture("idfff.png", DFFF,  0xFF, 0, Snow, 0.5, 1.0); 
   LS::addTerrainTexture("ifddd.png", FDDD,  0xFF, 0, Snow, 0.5, 1.0); 
   LS::addTerrainTexture("iyyyy7.png", YYYY, 0xFF, 3, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy6.png", YYYY, 0xFF, 3, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy5.png", YYYY, 0xFF, 3, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy4.png", YYYY, 0xFF, 3, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy3.png", YYYY, 0xFF, 22, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy2.png", YYYY, 0xFF, 22, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy1.png", YYYY, 0xFF, 22, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyyyy.png", YYYY, 0xFF, 22, Stone, 0.5, 1.0 ); 
   LS::addTerrainTexture("ixxxx3.png", XXXX, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ixxxx2.png", XXXX, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ixxxx1.png", XXXX, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ixxxx.png", XXXX, 0xFF, 25, PackedEarth, 0.5, 1.0); 
   LS::addTerrainTexture("ipath2.png", FFPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath2a.png", FFPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath2b.png", FFPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath2c.png", FFPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath1.png", FFFP, 0xFF, 50, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath1a.png", FFFP, 0xFF, 50, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath3.png", FFFP, 0, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath3a.png", FFFP, 0, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath4.png", PPFP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath4a.png", PPFP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath4b.png", PPFP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath4c.png", PPFP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipathcurve1.png", FPFP, 0xFF, 33, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipathcurve1a.png", FPFP, 0xFF, 33, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipathcurve1b.png", FPFP, 0xFF, 34, Snow, 0.5, 1.0);
   LS::addTerrainTexture("idfxx.png", DFXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("idxxx.png", DXXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ifxxx.png", FXXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ixddd.png", XDDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ixdff.png", XDFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ixfdd.png", XFDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ixfff.png", XFFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ixxdd.png", XXDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ixxff.png", XXFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iIIII3.png", IIII, 0xFF, 25, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iIIII2.png", IIII, 0xFF, 25, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iIIII1.png", IIII, 0xFF, 25, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iIIII.png", IIII, 0xFF, 25, Ice, 0.5, 1.0);
   LS::addTerrainTexture("idfii.png", DFII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("idiii.png", DIII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("idxii.png", DXII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("ifiii.png", FIII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("ifxii.png", FXII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iiddd.png", IDDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iidff.png", IDFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iidxx.png", IDXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iifdd.png", IFDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iifff.png", IFFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iifxx.png", IFXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iiidd.png", IIDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iiiff.png", IIFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iiixx.png", IIXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iixdd.png", IXDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iixff.png", IXFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iixxx.png", IXXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("ixiii.png", XIII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("idfyy.png", DFYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("idiyy.png", DIYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("idxyy.png", DXYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("idyyy.png", DYYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("ifiyy.png", FIYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("ifxyy.png", FXYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("ifyyy.png", FYYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iixyy.png", IXYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iiyyy.png", IYYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("ixyyy.png", XYYY, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("iyddd.png", YDDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iydff.png", YDFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iydii.png", YDII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iydxx.png", YDXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyfdd.png", YFDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyfff.png", YFFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyfii.png", YFII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iyfxx.png", YFXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyidd.png", YIDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyiff.png", YIFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyiii.png", YIII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iyixx.png", YIXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyxdd.png", YXDD, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyxff.png", YXFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyxii.png", YXII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iyxxx.png", YXXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iyydd.png", YYDD, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyyff.png", YYFF, 0xFF, 0, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iyyii.png", YYII, 0xFF, 0, Ice, 0.5, 1.0);
   LS::addTerrainTexture("iyyxx.png", YYXX, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF,  0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF,  0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF,  0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff3.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff4.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("iffff2.png", FFFF, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath5.png", PPPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath5a.png", PPPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath5b.png", PPPP, 0xFF, 25, Snow, 0.5, 1.0);
   LS::addTerrainTexture("ipath5c.png", PPPP, 0xFF, 25, Snow, 0.5, 1.0);

   // create the dat and dml for this world
   LS::createGridFile("temp/ice.grid.dat", "temp/ice.dml");
}
