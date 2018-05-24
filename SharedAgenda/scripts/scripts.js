function addEntryToTimeTable(weekday,titleString/*,description,subject,occuringTime*/) {
    var container = document.createElement("div");
    var title = document.createElement("h4");
    /*var desc = document.createElement("p");
    var subj = document.createElement("p");
    var time = document.createElement("p");*/
    console.log("elements created");

    container.setAttribute("class", "eintragsDiv");
    title.setAttribute("class", "eintragsh4");
    title.textContent = titleString;
    console.log(title.textContent);
    /*desc.setAttribute("class", "eintragsP");
    desc.textContent = description;
    console.log(desc.textContent);
    subj.setAttribute("class", "eintragsPFach");
    subj.textContent = subject;
    console.log(subj.textContent);
    time.setAttribute("class", "eintragsZeit");
    time.textContent = occuringTime;
    console.log(time.textContent);*/

    container.appendChild(title);
    /*container.appendChild(desc);
    container.appendChild(subj);
    container.appendChild(time);*/
    console.log("appendChild Complete!");

    document.getElementById(weekday).appendChild(container);
    Console.log("container added!");

}