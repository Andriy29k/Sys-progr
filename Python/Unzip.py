import os
import zipfile

def unzip(zip_file_path, dest_directory):
    if not os.path.exists(dest_directory):
        os.makedirs(dest_directory)

    zip_ref = zipfile.ZipFile(zip_file_path, 'r')
    try:
        for entry in zip_ref.namelist():
            file_path = os.path.join(dest_directory, entry)

            if entry.endswith('/'):
                if not os.path.exists(file_path):
                    os.makedirs(file_path)
            else:
                with zip_ref.open(entry) as source:
                    with open(file_path, 'wb') as target:
                        target.write(source.read())
    finally:
        zip_ref.close()

zip_file_path = 'D:\\Archive.zip'
dest_directory = 'D:\\UnZipToHere\\'

try:
    unzip(zip_file_path, dest_directory)
    print("Unzipping completed successfully.")
except Exception as e:
    print("An error occurred while unzipping the file.")
    print(e)
