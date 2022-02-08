//---------------------------------------------------------
// lush terrain file
//---------------------------------------------------------

// the terrain types for this world
function Terrain::Lush::setTypes()
{
   LS::flushTextures();
   
   LS::addTerrainType(F, " 1 Dirt");
   LS::addTerrainType(N, " 2 Dirt medium grass");
   LS::addTerrainType(C, " 3 Dirt much grass");
   LS::addTerrainType(R, " 4 Rock");
   LS::addTerrainType(H, " 5 Cracked Earth");
   LS::addTerrainType(P, " 6 Path");
   LS::addTerrainType(G, " 7 Concrete pad");
   LS::addTerrainType(X, " 8 Concrete road pad");
   LS::addTerrainType(S, " 9 Half rock - half sand");
}

// default rules for this world type
function Terrain::Lush::setRules()
{
   Terrain::Lush::setTypes();
   LS::flushRules();

   LS::addRule(F, 50.0,  350.0, 150.0, 0.50, 0.50, 0, 0.00, 8.0, 1.5, 0.50, 0.50, 0);
   LS::addRule(N, 15.0,  305.0, 25.0,  0.50, 0.50, 0, 0.10, 4.0, 0.5, 0.50, 0.50, 0);
   LS::addRule(C, 0.0,   450.0, 100.0, 0.50, 0.50, 0, 0.00, 2.0, 0.3, 0.50, 0.50, 0);
   LS::addRule(R, 150.0, 400.0, 150.0, 0.50, 0.40, 0, 0.00, 8.0, 0.5, 0.50, 0.30, 0);
   LS::addRule(H, 0.0,   185.0, 05.0,  0.10, 0.05, 0, 0.00, 1.0, 0.1, 0.60, 0.40, 0);
}

// create the grid file and dml for this world
function Terrain::Lush::createGridFile()
{
   Terrain::Lush::setTypes();

   LS::addTerrainTexture("lCCCC.png", CCCC, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCCC1.png", CCCC, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCCC2.png", CCCC, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCCC3.png", CCCC, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCCC4.png", CCCC, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCFF.png", CCFF, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCNN.png", CCNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCCRR.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCFFF.png", CFFF, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lCFHH.png", CFHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCFNN.png", CFNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCFRR.png", CFRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCHHH.png", CHHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCNFF.png", CNFF, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lCNHH.png", CNHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCNNN.png", CNNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCNRR.png", CNRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCRFF.png", CRFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCRNN.png", CRNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCRRR.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lFCCC.png", FCCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFFFF.png", FFFF, 0xFF, 33, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lFFFF2.png", FFFF, 0xFF, 33, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lFFFF3.png", FFFF, 0xFF, 34, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lFFRR.png", FFRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lFHHH.png", FHHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFNCC.png", FNCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFNHH.png", FNHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFNNN.png", FNNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFNRR.png", FNRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lFRNN.png", FRNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFRRR.png", FRRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lHCCC.png", HCCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHCFF.png", HCFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHCNN.png", HCNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHFCC.png", HFCC, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHFFF.png", HFFF, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lHFNN.png", HFNN, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHCC.png", HHCC, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHFF.png", HHFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHHH.png", HHHH, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHHH1.png", HHHH, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHHH2.png", HHHH, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHHH3.png", HHHH, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHHH4.png", HHHH, 0xFF, 20, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHHNN.png", HHNN, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHNCC.png", HNCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHNFF.png", HNFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHNNN.png", HNNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNCCC.png", NCCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNFFF.png", NFFF, 0xFF, 0, Sand, 0.5, 1.0);
   LS::addTerrainTexture("lNHHH.png", NHHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNFF.png", NNFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNNN.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNNN1.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNNN2.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNNN3.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNNN4.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lNNRR.png", NNRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lNRRR.png", NRRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRCCC.png", RCCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRFCC.png", RFCC, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRFFF.png", RFFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRNCC.png", RNCC, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRNFF.png", RNFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRNNN.png", RNNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR.png", RRRR, 0xFF, 12, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR1.png", RRRR, 0xFF, 12, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR2.png", RRRR, 0xFF, 12, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR3.png", RRRR, 0xFF, 12, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lGGCC.png" , GGCC, 0xFF, 50, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lGGCC1.png", GGCC, 0xFF, 50, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lCCGG.png" , GGCC, 0, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lCCGG1.png", GGCC, 0, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lCGGG.png" , CGGG, 0xFF, 50, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lCGGG1.png", CGGG, 0xFF, 50, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lGCCC.png" , GCCC, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lGCCC1.png", GCCC, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lGGGG.png" , GGGG, 0xFF, 100, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO1.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO2.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO3.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO4.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO5.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO6.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO7.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO8.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO9.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lLOGO10.png", GGGG, 0xFF, 0, Concrete, 0.5, 1.0);
   LS::addTerrainTexture("lPath2.png", CCPP, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath2a.png", CCPP, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath2b.png", CCPP, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath2c.png", CCPP, 0xFF, 25, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath1.png", CCCP, 0xFF, 100, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath3.png", CCCP, 0, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath3a.png", CCCP, 0, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath4.png", PPCP, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath4a.png", PPCP, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath5.png", PPPP, 0xFF, 33, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath5a.png", PPPP, 0xFF, 33, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath5b.png", PPPP, 0xFF, 34, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPathCURVE.png", CPCP, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPathCURVE2.png", CPCP, 0xFF, 50, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn1.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn2.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn3.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn4.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn1.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn2.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn3.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn4.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn1.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn2.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5b.png", PPPP, 0xFF, 34, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lpath5a.png", PPPP, 0xFF, 33, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn1.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn2.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lnnnn3.png", NNNN, 0xFF, 20, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRCNN.png", RCNN, 0xFF, 0, SoftEarth, 0.5, 1.0);
   LS::addTerrainTexture("lCHRR.png", CHRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lHRRR.png", HRRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRCHH.png", RCHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRHCC.png", RHCC, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRHHH.png", RHHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lHNRR.png", HNRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRHNN.png", RHNN, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRNHH.png", RNHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lFHRR.png", FHRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRFHH.png", RFHH, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRHFF.png", RHFF, 0xFF, 0, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR4.png", RRRR, 0xFF, 13, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR5.png", RRRR, 0xFF, 13, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR6.png", RRRR, 0xFF, 13, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRRR7.png", RRRR, 0xFF, 13, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCRRR1.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCRRR2.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCRRR3.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCRRR4.png", CRRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCCRR1.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCCRR2.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCCRR3.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lCCRR4.png", CCRR, 0xFF, 20, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lPathCURVE1.png", CPCP, 0xFF, 34, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lPath4B.png", PPCP, 0xFF, 34, PackedEarth, 0.5, 1.0);
   LS::addTerrainTexture("lRRSS.png", RRSS, 0xFF, 33, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRSS1.png", RRSS, 0xFF, 33, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRSSS.png", RSSS, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lSRRR.png", SRRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lssss.png", SSSS, 0xFF, 25, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lssss1.png", SSSS, 0xFF, 25, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lssss2.png", SSSS, 0xFF, 25, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lssss3.png", SSSS, 0xFF, 25, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lHHRR.png", HHRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lffss.png", FFSS, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lfSss.png", FSSS, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lSfFF.png", SFFF, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lfRss.png", FRSS, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lfSRR.png", FSRR, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRSFF.png", RSFF, 0xFF, 0, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lsrrr1.png", SRRR, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRSSS.png", RSSS, 0xFF, 50, Stone, 0.5, 1.0);
   LS::addTerrainTexture("lRRSS2.png", RRSS, 0xFF, 34, Stone, 0.5, 1.0);

   // create the dat and dml for this world
   LS::createGridFile("temp/lush.grid.dat", "temp/lush.dml");
}
