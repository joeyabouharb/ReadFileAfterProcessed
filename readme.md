# Check Process Finished Writing File

this is an example showing how to check if there is a lock on a file prior to processing it in our main program. This demo is helpful to ensure a file can be read safely once an external process has finished writing it. This Program uses Windows own restart manager API to check processes that are working on a specified file. (It remains unknown if this is actually thread safe) :(


