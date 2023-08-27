# huggingface download script using huggingface_hub

# import libraries
from huggingface_hub import Repository, snapshot_download, create_repo, get_full_repo_name, notebook_login
import os

# define variables
model_author = "name" # ex KoboldAI
model_name = "model" # ex GPT-NeoX-20B-Erebus

# make folder
os.mkdir(f"/content/")
os.mkdir(f"/content/{model_name}")

# make sure lfs is installed
os.system("git lfs install")

# download model
repo = Repository(
    f"{model_author}/{model_name}",
    clone_from=f"{model_author}/{model_name}",
)
snapshot_download(repo, revision="main", output_dir=f"/content/{model_name}")

# download tokenizer
repo = Repository(
    f"{model_author}/{model_name}-tokenizer",
    clone_from=f"{model_author}/{model_name}-tokenizer",
)
snapshot_download(repo, revision="main", output_dir=f"/content/{model_name}")

# download config
repo = Repository(
    f"{model_author}/{model_name}-config",
    clone_from=f"{model_author}/{model_name}-config",
)
snapshot_download(repo, revision="main", output_dir=f"/content/{model_name}")

# print model info and that it's done
print(f"Model: {model_name}")
print("Done!")
