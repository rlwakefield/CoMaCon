async function validateCacheFolderIsntAUncPath(cacheFolder) {
    console.log(document.getElementById(cacheFolder.id).value);
    if (document.getElementById(cacheFolder.id).value.startsWith('\\\\')) {
        //throw new Error('Cache folder cannot be a UNC path');
        pushErrorToArray(await findErrorArrayToSet("cachePathCannotBeAUncPath"));
    } else {
        spliceErrorFromArray("cachePathCannotBeAUncPath");
    }
}