using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // The number of seconds between decisions
    public float decisionTime = 10f;
    private float timeSinceLastDecision;

    private EnemyController controller;
    // The empty game object that holds all the generators and information the AIs need to know
    [SerializeField]
    private AIManager manager;

    public List<Option> currentOptions = new List<Option>{new DefaultOption()};

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastDecision = decisionTime;
        if(controller == null){
            controller = GetComponent<EnemyController>();
        }
        manager = GameObject.FindWithTag("AIManager").GetComponent<AIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Runs current options until it they are no longer relevant or the time expires
        if(timeSinceLastDecision >= decisionTime) {
            PickNewOptions();
        }
        foreach(Option o in currentOptions){
            if(!o.Update()){
                PickNewOptions();
                break;
            }
        }
        timeSinceLastDecision += Time.deltaTime;
    }

    // Resets currentOptions
    private void PickNewOptions(){
        List<Option> options = new List<Option>();
        foreach(Generator generator in manager.GetGenerators()){
            // Finds options within a reasonable
            options.AddRange(generator.generateOptions(gameObject, controller.GetCurrentTarget(), 100));
        }
        options = OptionChooser.PruneOptions(options, gameObject, controller.GetCurrentTarget());
        foreach(Option o in options){
            o.SetUtility(OptionChooser.RateOption(o, gameObject, controller.GetCurrentTarget()));
        }
        options.Sort(OptionChooser.CompareOptionsByUtility);
        
        currentOptions = new List<Option>();
        List<OptionTag> curTags = new List<OptionTag>();
        foreach(Option o in options){
            bool intersect = false;
            // TODO: this seems inefficient but the lists are small enough it shouldn't matter
            foreach(OptionTag curT in curTags){
                foreach(OptionTag t in o.tags){
                    if(curT == t){
                        intersect = true;
                        break;
                    }
                }
                if(intersect) break;
            }
            if(intersect) continue;
            o.Select(gameObject, controller.GetCurrentTarget());
            currentOptions.Add(o);
            curTags.AddRange(o.tags);
        }
    }
}
