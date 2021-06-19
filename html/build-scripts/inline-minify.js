const fs = require("fs");
const path = require("path");
const inline = require("web-resource-inliner");
const minify = require("html-minifier").minify;

const inputDir = "./src/";
const outputDir = "./dist/";

const htmlInlineOptions = {
    maxImageInlineSizeKB: 8
}

// Clear resources content so that old files do not get included in Resources.resx
fs.readdirSync(outputDir).forEach(file => {
    fs.unlinkSync(outputDir + file);
});

fs.readdir(inputDir, { withFileTypes: true }, (err, result) => {
    if (err) {
        throw err;
    }

    // Filter out folders
    const noFolders = result.filter(dirent => dirent.isFile());

    // Replace dirent object with file name
    const files = noFolders.map(dirent => dirent.name);

    // Get only .html files
    const htmlFiles = files.filter(file => path.extname(file) === ".html");

    // For each .html file, inline and minify
    htmlFiles.forEach(file => {
        
        console.log("inlining => " + file);

        fs.readFile(inputDir + file, "utf-8", (err, content) => {
            if (err) {
                throw err;
            }

            // Create inline html string with custom options
            inline.html({
                fileContent: content,
                images: htmlInlineOptions.maxImageInlineSizeKB,
                svgs: htmlInlineOptions.maxImageInlineSizeKB,
                relativeTo: inputDir
            }, function (err, inlinedContent) {
                if (err) {
                    throw err;
                }

                // The inlined content is stored now in inlinedContent
                console.log("inlined => " + file);
                console.log("minifying => " + file);

                const minifiedContent = minify(inlinedContent, {});

                fs.writeFile(outputDir + file, minifiedContent, (err) => {
                    if (err) {
                        throw err;
                    }
                    console.log("saving file to => " + outputDir + file);
                });
            });
        });
    });
});