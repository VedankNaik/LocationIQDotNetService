#!/bin/bash
# "Command renames the solution structure for the new .NET Core service by replacing the term Template

###########################################
### Please modify the following parameters: 
NEW_PROJ_NAME=SwaggerService
NEW_SLN_NAME=swagger.service
###########################################

#### Don't modify anything else below

SLN_NAME=service.template
PROJ_NAME=IAZI.Service.Template

PROJ_NAME_MAIN=$PROJ_NAME".Web"
PROJ_NAME_CORE=$PROJ_NAME".Core"
PROJ_NAME_INFR=$PROJ_NAME".Infrastructure"
TEST_PROJ_NAME_MAIN=$PROJ_NAME_MAIN".Test"
TEST_PROJ_NAME_CORE=$PROJ_NAME_CORE".Test"
TEST_PROJ_NAME_INFR=$PROJ_NAME_INFR".Test"
TEST_PROJ_NAME_INGR=$PROJ_NAME".Integration.Test"
TEST_PROJ_NAME_ACCPT=$PROJ_NAME".Acceptance.Test"
TEST_PROJ_NAME_COMP=$PROJ_NAME".Component.Test"

NEW_PROJ_NAME_MAIN=$NEW_PROJ_NAME".Web"
NEW_PROJ_NAME_CORE=$NEW_PROJ_NAME".Core"
NEW_PROJ_NAME_INFR=$NEW_PROJ_NAME".Infrastructure"
NEW_PROJ_NAME_INGR=$NEW_PROJ_NAME".Integration"
NEW_PROJ_NAME_ACCPT=$NEW_PROJ_NAME".Acceptance"
NEW_PROJ_NAME_COMP=$NEW_PROJ_NAME".Component"

NEW_TEST_PROJ_NAME_MAIN=$NEW_PROJ_NAME_MAIN".Test"
NEW_TEST_PROJ_NAME_CORE=$NEW_PROJ_NAME_CORE".Test"
NEW_TEST_PROJ_NAME_INFR=$NEW_PROJ_NAME_INFR".Test"
NEW_TEST_PROJ_NAME_INGR=$NEW_PROJ_NAME_INGR".Test"
NEW_TEST_PROJ_NAME_ACCPT=$NEW_PROJ_NAME_ACCPT".Test"
NEW_TEST_PROJ_NAME_COMP=$NEW_PROJ_NAME_COMP".Test"

SRC_FOLDER_NAME="src"
TEST_FOLDER_NAME="test"

echo Renaming solution: $SLN_NAME

# Directory and project files

mv $SRC_FOLDER_NAME/$PROJ_NAME_MAIN $SRC_FOLDER_NAME/$NEW_PROJ_NAME_MAIN
mv $SRC_FOLDER_NAME/$NEW_PROJ_NAME_MAIN/$PROJ_NAME_MAIN".csproj" $SRC_FOLDER_NAME/$NEW_PROJ_NAME_MAIN/$NEW_PROJ_NAME_MAIN".csproj"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_MAIN"/bin"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_MAIN"/obj"

mv $SRC_FOLDER_NAME/$PROJ_NAME_CORE $SRC_FOLDER_NAME/$NEW_PROJ_NAME_CORE
mv $SRC_FOLDER_NAME/$NEW_PROJ_NAME_CORE/$PROJ_NAME_CORE".csproj" $SRC_FOLDER_NAME/$NEW_PROJ_NAME_CORE/$NEW_PROJ_NAME_CORE".csproj"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_CORE"/bin"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_CORE"/obj"

mv $SRC_FOLDER_NAME/$PROJ_NAME_INFR $SRC_FOLDER_NAME/$NEW_PROJ_NAME_INFR
mv $SRC_FOLDER_NAME/$NEW_PROJ_NAME_INFR/$PROJ_NAME_INFR".csproj" $SRC_FOLDER_NAME/$NEW_PROJ_NAME_INFR/$NEW_PROJ_NAME_INFR".csproj"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_INFR"/bin"
rm -rf $SRC_FOLDER_NAME/$NEW_PROJ_NAME_INFR"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_MAIN $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_MAIN
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_MAIN/$TEST_PROJ_NAME_MAIN".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_MAIN/$NEW_TEST_PROJ_NAME_MAIN".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_MAIN"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_MAIN"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_CORE $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_CORE
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_CORE/$TEST_PROJ_NAME_CORE".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_CORE/$NEW_TEST_PROJ_NAME_CORE".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_CORE"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_CORE"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_INFR $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INFR
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INFR/$TEST_PROJ_NAME_INFR".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INFR/$NEW_TEST_PROJ_NAME_INFR".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INFR"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INFR"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_INGR $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INGR
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INGR/$TEST_PROJ_NAME_INGR".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INGR/$NEW_TEST_PROJ_NAME_INGR".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INGR"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_INGR"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_ACCPT $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_ACCPT
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_ACCPT/$TEST_PROJ_NAME_ACCPT".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_ACCPT/$NEW_TEST_PROJ_NAME_ACCPT".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_ACCPT"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_ACCPT"/obj"

mv $TEST_FOLDER_NAME/$TEST_PROJ_NAME_COMP $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_COMP
mv $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_COMP/$TEST_PROJ_NAME_COMP".csproj" $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_COMP/$NEW_TEST_PROJ_NAME_COMP".csproj"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_COMP"/bin"
rm -rf $TEST_FOLDER_NAME/$NEW_TEST_PROJ_NAME_COMP"/obj"

# Solution file
mv $SLN_NAME".sln" $NEW_SLN_NAME".sln"

walk_dir () {
    shopt -s nullglob dotglob
    for pathname in "$1"/*; do
        if [ -d "$pathname" ]; then
            walk_dir "$pathname"
        elif [ -e "$pathname" ]; then
            case "$pathname" in
                *.cs|*.csproj|*.sln|*.gitignore*|*Dockerfile*|*.json)
                    printf '%s\n' "$pathname"
                    sed -i 's/'$PROJ_NAME'/'$NEW_PROJ_NAME'/g' "$pathname"
                    sed -i 's/'$SLN_NAME'/'$NEW_SLN_NAME'/g' "$pathname"                    
            esac
        fi
    done
}

walk_dir .

echo Solution $SLN_NAME renamed
