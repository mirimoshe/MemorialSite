import React from 'react';
import '../pictureStyle.css';


function Picture() {
    let backgroundStory="The story behind the picture";
  return (
    <div>
        <image src="flowers.jpg" alt="floers" className='image'></image>
        <div class="overlay">{backgroundStory}</div>
        <div></div>
    </div>
  )
}

export default Picture