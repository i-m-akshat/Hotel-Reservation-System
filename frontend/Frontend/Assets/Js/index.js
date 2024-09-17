  const setImageMain = (cardID, newImageSrc) => {
            const mainImage = document.querySelector(`#${cardID} .main-image`);
            console.log(mainImage);
            if (mainImage) {
                mainImage.src = newImageSrc;
            }
        };

        document.querySelectorAll('.side-img').forEach(sideImage => {
            sideImage.addEventListener('click', function () {
                const cardID = this.closest('.card').id;
                const newImageSrc = this.src;
                console.log(cardID);
                setImageMain(cardID, newImageSrc);
            });
        });