function onClientMessage_hook(%cl, %msg, %type) before onClientMessage
{
	if(%cl && (%type == 2 || %type == 3) )
	{
		%index = String::findSubStr( %msg, "~" );
		if ( %index != -1 ) 
		{
			%tags = String::getSubStr( %msg, %index + 2, 1000 );			
			if(!$s::sndList[%tags])			
				halt;			
		}	
	}
}

$s::sndList[attack] = true;
$s::sndList[attac2] = true;
$s::sndList[attbase] = true;
$s::sndList[attenem] = true;
$s::sndList[gooff] = true;
$s::sndList[ono] = true;

$s::sndList[isbsclr] = true;
$s::sndList[bsclr2] = true;
$s::sndList[basetkn] = true;
$s::sndList[basundr] = true;

$s::sndList[thanks] = true;
$s::sndList[noprob] = true;
$s::sndList[wshoot1] = true;
$s::sndList[bye] = true;
$s::sndList[hello] = true;
$s::sndList[yes] = true;
$s::sndList[no] = true;
$s::sndList[sorry] = true;
$s::sndList[dontkno] = true;
$s::sndList[color3] = true;

$s::sndList[acknow] = true;
$s::sndList[belay] = true;
$s::sndList[boarda] = true;
$s::sndList[ordcan] = true;
$s::sndList[objcomp] = true;
$s::sndList[desgen] = true;
$s::sndList[destur] = true;
$s::sndList[objxcmp] = true;

$s::sndList[cease] = true;
$s::sndList[coverme] = true;
$s::sndList[hitdeck] = true;
$s::sndList[outway] = true;
$s::sndList[moveout] = true;
$s::sndList[ovrhere] = true;
$s::sndList[proceed] = true;
$s::sndList[ready] = true;
$s::sndList[regroup] = true;
$s::sndList[retreat] = true;
$s::sndList[stop] = true;
$s::sndList[takcovr] = true;
$s::sndList[wait1] = true;
$s::sndList[wait2] = true;
$s::sndList[waitsig] = true;

$s::sndList[depamo] = true;
$s::sndList[depbecn] = true;
$s::sndList[depcam] = true;
$s::sndList[depinv] = true;
$s::sndList[depjamr] = true;
$s::sndList[depmot] = true;
$s::sndList[deppuls] = true;

$s::sndList[clrflg] = true;
$s::sndList[geteflg] = true;
$s::sndList[haveflg] = true;
$s::sndList[mineflg] = true;
$s::sndList[flgmine] = true;
$s::sndList[flagtkn1] = true;
$s::sndList[retflag] = true;
$s::sndList[flaghm] = true;
$s::sndList[flgtkm2] = true;
$s::sndList[flgtkn1] = true;

$s::sndList[needamo] = true;
$s::sndList[needpku] = true;
$s::sndList[needesc] = true;
$s::sndList[needrep] = true;
$s::sndList[hurystn] = true;

$s::sndList[attobj] = true;
$s::sndList[capobj] = true;
$s::sndList[clrobj] = true;
$s::sndList[defobj] = true;
$s::sndList[getobj] = true;
$s::sndList[mineobj] = true;
$s::sndList[repobj] = true;
$s::sndList[defbase] = true;
$s::sndList[godef] = true;
$s::sndList[basatt] = true;
$s::sndList[defend] = true;
$s::sndList[mineclr] = true;
$s::sndList[needdef] = true;

$s::sndList[gendes] = true;
$s::sndList[turdes] = true;
$s::sndList[waitpas] = true;

$s::sndList[firetgt] = true;
$s::sndList[tgtacq] = true;
$s::sndList[tgtobj] = true;
$s::sndList[tgtout] = true;
$s::sndList[needtgt] = true;

$s::sndList[taunt1] = true;
$s::sndList[taunt10] = true;
$s::sndList[tautn11] = true;
$s::sndList[taunt2] = true;
$s::sndList[taunt3] = true;
$s::sndList[taunt4] = true;

$s::sndList[attway] = true;
$s::sndList[defway] = true;
$s::sndList[escfr] = true;
$s::sndList[goway] = true;
$s::sndList[wpilot] = true;
$s::sndList[repplyr] = true;
$s::sndList[repitem] = true;

$s::sndList[color2] = true;
$s::sndList[color6] = true;
$s::sndList[color7] = true;
$s::sndList[dsgst1] = true;
$s::sndList[dsgst2] = true;
$s::sndList[wshoot3] = true;
$s::sndList[dsgst4] = true;
$s::sndList[dsgst5] = true;
$s::sndList[oops1] = true;
$s::sndList[oops2] = true;
$s::sndList[cheer1] = true;
$s::sndList[cheer2] = true;
$s::sndList[cheer3] = true;
$s::sndList[help] = true;

$s::sndList[incom2] = true;

$s::sndList[depapad] = true;
$s::sndList[depobj] = true;
$s::sndList[deseqip] = true;
$s::sndList[doh] = true;
$s::sndList[flgtkn2] = true;
$s::sndList[goto] = true;
$s::sndList[isbclr] = true;
$s::sndList[offflg] = true;
$s::sndList[oops] = true;
$s::sndList[watchsh] = true;
$s::sndList[wshoot] = true;
$s::sndList[death] = true;
$s::sndList[whit] = true;
$s::sndList[mfbeast] = true;
$s::sndList[fom] = true;
$s::sndList[hmd] = true;
$s::sndList[cp] = true;
$s::sndList[hmd2] = true;
$s::sndList[nycgmd] = true;
$s::sndList[hlb] = true;